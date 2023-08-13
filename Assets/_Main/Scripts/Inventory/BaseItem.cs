using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : BaseMonoBehaviour
{
    [SerializeField] private ItemSO _itemSO;
    [SerializeField] private int _value = 1;
    public ItemSO _ItemSO
    {
        get => _itemSO;
    }

    public int _Value
    {
        get => _value;
    }
}
