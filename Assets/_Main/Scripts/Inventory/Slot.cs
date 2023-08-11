using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : BaseMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (this.transform.childCount > 1) return;

        GameObject current = eventData.pointerDrag;
        Item currentItem = current.GetComponent<Item>();

        switch (this.transform.childCount)
        {
            case 0:
                SetItemNewSlot(currentItem);
                break;

            case 1:
                SwapItem(currentItem, current);
                break;
        }
    }

    private void SetItemNewSlot(Item current)
    {
        current.transform.SetParent(this.transform);
    }

    private void SwapItem(Item currentItem, GameObject current)
    {
        Transform itemReceive = this.transform.GetChild(0);
        itemReceive.SetParent(currentItem._OldParent);

        current.transform.SetParent(this.transform);
    }

    protected override void SetDefaultValue()
    {}
}