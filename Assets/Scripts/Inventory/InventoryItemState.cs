using System;

[Serializable]
public class InventoryItemState : IInventoryItemState
{
    public int itemAmount;
    public int amount { get => itemAmount; set => itemAmount = value; }

    public InventoryItemState()
    {
        itemAmount = 0;
    }
}
