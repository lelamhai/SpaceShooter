using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : BaseMonoBehaviour, IDataPersistence
{
    [SerializeField] private List<ItemSO> _listItemSO = new List<ItemSO>();
    public List<ItemSO> _ListItemSO
    {
        get => _listItemSO;
    }

    public void AddItem(BaseItem item)
    {
        Debug.Log("_TypeItem: " + item._ItemSO._TypeItem);

        var result = FindItem(item);

        if (result == null)
        {
            _listItemSO.Add(item._ItemSO);
        }
        else
        {
            result._CountItem += item._Value;
        }
    }

    private ItemSO FindItem(BaseItem item)
    {
        ItemSO result = _listItemSO.Where(q => q._TypeItem == item._ItemSO._TypeItem).FirstOrDefault();
        if (result == null) return null;
        return result;
    }

    private void RemoveItem()
    {}

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
    }

    public void SaveData(GameData data)
    {
    }
}