using System;

public class Gift : IInventoryItem
{
    public Type type => GetType();

    public int maxItemsInInventorySlot { get; }

    public int amount { get; set; }

    public IInventoryItemInfo info { get;}

    public IInventoryItemState state { get;}

    public Gift(IInventoryItemInfo info)
    {
        this.info = info;
        state = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedGift = new Gift(info);
        clonedGift.state.amount = state.amount;
        return clonedGift;
    }
}
