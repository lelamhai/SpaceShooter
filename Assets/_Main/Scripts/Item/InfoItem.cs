using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoItem : BaseMonoBehaviour
{
    [SerializeField] private ItemSO _itemSO;
    public ItemSO _ItemSO
    {
        get => _itemSO;
    }

    protected override void SetDefaultValue()
    {}
}
