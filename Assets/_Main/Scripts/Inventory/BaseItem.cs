using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : BaseMonoBehaviour
{
    [SerializeField] private AttributeItem _attributeItem;
    [SerializeField] private int _amount = 1;
    public AttributeItem _AttributeItem
    {
        get => _attributeItem;
    }

    public int _Amount
    {
        get => _amount;
    }
}