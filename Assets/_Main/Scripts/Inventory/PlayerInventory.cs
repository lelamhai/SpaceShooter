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

        if (InventoryEmpty())
        {
            CreateAttributeItem(item, item._Amount);
        } else
        {
            AddAttributeItem(item);
        }

        SetSlotItem();
    }

    private void SetSlotItem()
    {
        for (int i = 0; i < 12; i++)
        {
            if(i < _inventory.Count)
            {
                _inventory[i].Slot = i;
            } 
        }
    }

    private bool InventoryEmpty()
    {
        if (_Inventory.Count == 0)
        {
            return true;
        }
        return false;
    }

    private void AddAttributeItem(BaseItem item)
    {
       bool createEmpty = false;

        foreach (var i in _Inventory.ToList())
        {
            if (i.AttributeItem.Id == item._AttributeItem.Id)
            {
                if (i.AttributeItem.QuantityItem == item._AttributeItem.MaxItem) continue;
                createEmpty = true;

                var total = i.AttributeItem.QuantityItem + item._Amount;

                if (total <= item._AttributeItem.MaxItem)
                {
                    i.AttributeItem.QuantityItem = total;
                }

                while (total > item._AttributeItem.MaxItem)
                {
                    int addValue = item._AttributeItem.MaxItem - i.AttributeItem.QuantityItem;
                    i.AttributeItem.QuantityItem += addValue;
                    total -= item._AttributeItem.MaxItem;

                    if (total < item._AttributeItem.MaxItem)
                    {
                        CreateAttributeItem(item, total);
                    }
                    else
                    {
                        CreateAttributeItem(item, item._AttributeItem.MaxItem);
                    }
                }
            }
        }

        if(!createEmpty)
        {
            CreateAttributeItem(item, item._Amount);
        }
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