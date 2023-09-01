using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>, IDataPersistence
{
    [SerializeField] private List<AttributeSlot> _inventory = new List<AttributeSlot>();

    public List<AttributeSlot> _Inventory
    {
        get => _inventory;
    }

    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    public void AddItem(BaseItem item)
    {
        if (CheckFullInventory()) return;

        //if(!CheckInventoryEmpty())
        //{
        //    CreateAttributeItem(item);
        //    return;
        //}

        AddAttributeItem(item);
    }

    private void AddAttributeItem(BaseItem item)
    {
        foreach (var i in _Inventory.ToList())
        {
            if (i.AttributeItem.Id == item._AttributeItem.Id)
            {
                var total = i.AttributeItem.QuantityItem + item._PlusValue;

                if (total <= item._AttributeItem.MaxItem)
                {
                    i.AttributeItem.QuantityItem = total;
                }

                while (total >= item._AttributeItem.MaxItem)
                {
                    int temp = item._AttributeItem.MaxItem - i.AttributeItem.QuantityItem;
                    i.AttributeItem.QuantityItem += temp;
                    total -= (temp + item._PlusValue);

                    if (total < item._AttributeItem.MaxItem)
                    {
                        CreateAttributeItem(item, total);
                        return;
                    }
                    CreateAttributeItem(item, item._AttributeItem.MaxItem);
                }
                return;
            }
        }

        CreateAttributeItem(item, item._PlusValue);
    }

    private bool CheckFullInventory()
    {
        if (_inventory.Count < 12)
        {
            return false;
        }
        return true;
    }

    private AttributeItem CreateAttributeItem(BaseItem item, int quantity)
    {
        var attribueItem = new AttributeItem();
        attribueItem = item._AttributeItem;
        attribueItem.QuantityItem = quantity;
        _inventory.Add(new AttributeSlot(attribueItem,-1));
        return attribueItem;
    }


    //public void AddItem(BaseItem item)
    //{
    //    var result = FindItem(item._AttributeItem);

    //    if (result == null)
    //    {
    //        result = item._AttributeItem;
    //        _inventory.Add(new AttributeISlot(result, -1));
    //    }
    //    else
    //    {
    //        if (result.MaxItem >= result.QuantityItem)
    //        {
    //            result.QuantityItem += item._Value;
    //        }
    //        else
    //        {
    //            result = item._AttributeItem;
    //            _inventory.Add(new AttributeISlot(result, -1));
    //        }
    //    }
    //}





    private AttributeItem FindItem(AttributeItem item)
    {
        foreach (var i in _inventory)
        {
            if(i.AttributeItem.Id == item.Id)
            {
                return i.AttributeItem;
            }
        }
        return null;
    }

    private void RemoveItem(int id)
    {}

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
        foreach (var item in data.Inventory)
        {
            _inventory.Add(item);
        }
    }

    public void SaveData(GameData data)
    {
        data.Inventory = _inventory;
    }
}