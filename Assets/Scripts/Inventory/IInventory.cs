using System;

public interface IInventory
{
    int capacity { get; set; }
    bool IsFull { get; }

    IInventoryItem GetItem(Type itemType);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] GetAllItems(Type itemType);
    int GetItemAmount(Type itemType);

    bool TryToAdd(object sender, IInventoryItem item);
    void Remove(object sender, Type itemType, int amount = 1);
    bool HasItem(Type type, out IInventoryItem item);

}
