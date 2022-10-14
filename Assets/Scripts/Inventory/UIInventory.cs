using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _giftInfo;

    public InventoryWithSlots inventory => inventorySystem.inventory;
    [HideInInspector]public InventorySystem inventorySystem;

    private void Awake()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        inventorySystem = new InventorySystem(_giftInfo, uiSlots);
    }
}
