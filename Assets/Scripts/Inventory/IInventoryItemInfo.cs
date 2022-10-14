using UnityEngine;

public interface IInventoryItemInfo
{
    string id { get; }
    string title { get; }
    string description { get; }
    Sprite spriteIcon { get; }
    int MaxItemsInInventorySlot { get; }
}
