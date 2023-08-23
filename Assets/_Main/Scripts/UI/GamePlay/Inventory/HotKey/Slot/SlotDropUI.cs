using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDropUI : BaseMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (this.transform.childCount > 1) return;

        GameObject current = eventData.pointerDrag;
        ItemDragUI currentItem = current.GetComponent<ItemDragUI>();

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

    private void SetItemNewSlot(ItemDragUI current)
    {
        current.transform.SetParent(this.transform);
    }

    private void SwapItem(ItemDragUI currentItem, GameObject current)
    {
        Transform itemReceive = this.transform.GetChild(0);
        itemReceive.SetParent(currentItem._OldParent);

        current.transform.SetParent(this.transform);
    }

    protected override void SetDefaultValue()
    {}
}