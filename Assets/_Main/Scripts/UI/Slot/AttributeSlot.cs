using System;

[Serializable]
public class AttributeSlot
{
    public AttributeItem AttributeItem;
    public int Slot;
    public AttributeSlot()
    {
        this.Slot = -1;
    }

    public AttributeSlot(AttributeItem item, int slot)
    {
        this.Slot = slot;
        this.AttributeItem = item;
    }
}