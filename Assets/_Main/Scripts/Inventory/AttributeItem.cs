using System;
using UnityEngine;

[Serializable]
public class AttributeItem
{
    public int Id;
    public TypeItem TypeItem;
    public int MaxItem;
    public int QuantityItem;
    [TextArea]
    public string Description;

    public AttributeItem()
    {
        this.Id = -1;
        this.TypeItem = TypeItem.None;
        this.QuantityItem = 1;
        this.MaxItem = 2;
        this.Description = string.Empty;
    }

    public AttributeItem(int id, TypeItem typeItem, int totalItem, int quantityItem, string description)
    {
        this.Id = id;
        this.TypeItem = typeItem;
        this.MaxItem = totalItem;
        this.QuantityItem = quantityItem;
        this.Description = description;
    }
}