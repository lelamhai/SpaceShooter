using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasePrefabsUI : BaseMonoBehaviour
{
    [SerializeField] protected Transform _slot;
    [SerializeField] protected List<BaseItem> _listItem = new List<BaseItem>();

    public Transform _Slot
    {
        get => _slot;
    }

    public BaseItem FindItem(TypeItem typeItem)
    {
        BaseItem item = _listItem.Where(q=>q._AttributeItem.TypeItem == typeItem).FirstOrDefault();
        if(item == null)
        {
            return null;
        }
        return item;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        AddItem();
    }

    private void AddItem()
    {
        Transform parent = this.transform;
        foreach (Transform item in parent)
        {
            _listItem.Add(item.GetComponent<BaseItem>());
            item.gameObject.SetActive(false);

        }
    }
}
