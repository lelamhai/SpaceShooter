using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : BaseMonoBehaviour, IDataPersistence
{
    [SerializeField] private List<AttributeItem> _listItem = new List<AttributeItem>();

    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    public List<AttributeItem> _ListItem
    {
        get => _listItem;
    }

    public void AddItem(BaseItem item)
    {
        var result = FindItem(item._AttributeItem);

        if (result == null)
        {
            _listItem.Add(item._AttributeItem);
        }
        else
        {
            result.CountItem += item._Value;
        }
    }

    private AttributeItem FindItem(AttributeItem item)
    {
        AttributeItem result = _listItem.Where(q => q.TypeItem == item.TypeItem).FirstOrDefault();
        if (result == null) return null;
        return result;
    }

    private void RemoveItem()
    {}

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
        foreach (var item in data.Inventories)
        {
            _listItem.Add(item);
        }
    }

    public void SaveData(GameData data)
    {
        data.Inventories = _listItem;
    }
}