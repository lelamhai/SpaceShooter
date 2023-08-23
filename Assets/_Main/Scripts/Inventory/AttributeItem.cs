using System;
using UnityEngine;

[Serializable]
public class AttributeItem
{
    public int Id;
    public TypeItem TypeItem;
    public int MaxItem;
    public int CountItem;
    [TextArea]
    public string Description;
    public int PositionInventory;
    public int PositionHotKey;

    public AttributeItem()
    {
        this.Id = 1;
        this.TypeItem = TypeItem.None;
        this.MaxItem = 99;
        this.CountItem = 1;
        this.Description = string.Empty;
        this.PositionInventory = 0;
        this.PositionHotKey = -1;
    }

    public AttributeItem(int id, TypeItem typeItem, int maxItem, int countItem, string description, int positionInventory, int positionHotKey)
    {
        this.Id = id;
        this.TypeItem = typeItem;
        this.MaxItem = maxItem;
        this.CountItem = countItem;
        this.Description = description;
        this.PositionInventory = positionInventory;
        this.PositionHotKey = positionHotKey;
    }
}