using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private InventoryItemInfo _giftInfo;
    private UIInventorySlot[] _uiSlots;

    public InventoryWithSlots inventory { get; }

    public InventorySystem(InventoryItemInfo giftInfo, UIInventorySlot[] uiSlots)
    {
        _giftInfo = giftInfo;
        _uiSlots = uiSlots;

        inventory = new InventoryWithSlots(16);
        inventory.OnInventoryStateChangetEvent += OnInventoryStateChangetEvent;
    }

    private void OnInventoryStateChangetEvent(object sender)
    {
        foreach (var uiSlot in _uiSlots)
        {
            uiSlot.Refresh();
        }
    }

    public void FillSlots(InventoryItemInfo info, int amount)
    {
        var allSlots = inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = availableSlots[1];
        var gift = new Gift(info);
        gift.state.amount = amount;

        inventory.TryToAdd(this, gift);
        availableSlots.Remove(filledSlots);

        SetupInventoryUI(inventory);
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;

        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }
}
