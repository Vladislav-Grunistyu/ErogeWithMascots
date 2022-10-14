using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _giftInfo;
    [SerializeField] private UIInventory _uiInventory;

    private InventorySystem inventorySystem;
    private bool readyToOpen = false;

    private void GiveGift()
    {
        _uiInventory.inventorySystem.FillSlots(_giftInfo,1);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToOpen)
        {
            GiveGift();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            readyToOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            readyToOpen = false;
        }
    }
}
