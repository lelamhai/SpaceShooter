using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : BaseMonoBehaviour
{
    [SerializeField] private List<ItemSO> _listItemSO = new List<ItemSO>();
    [SerializeField] private int _coin = 0;
    public List<ItemSO> _ListItemSO
    {
        get => _listItemSO;
    }

    public void AddItem(ItemSO item)
    {
        _listItemSO.Add(item);
    }

    private void RemoveItem()
    {

    }

    public void AddCoin(int amount)
    {
        _coin += amount;
    }

    public void MinusCoin(int amount)
    {
        _coin -= amount;
    }

    protected override void SetDefaultValue()
    {}
}