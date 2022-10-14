using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowShow : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    private bool _inventoryActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !_inventoryActive)
        {
            ShowInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape) && _inventoryActive)
        {
            HideInventory();
        }
    }
    public void ShowInventory()
    {
        _inventory.SetActive(true);
        _inventoryActive = true;
    }
    public void HideInventory()
    {
        _inventory.SetActive(false);
        _inventoryActive = false;
    }
}
