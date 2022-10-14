using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private IInventory _inventory;

    private void Awake()
    {
        var inventoryCapacity = 16;
        _inventory = new InventoryWithSlots(inventoryCapacity);
        Debug.Log($"Inventory initialized, capacity: {inventoryCapacity}");
    }
}
