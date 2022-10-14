using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] 
    private UIInventoryItem _uiInventoryItem;
    public IInventorySlot slot { get; private set; }
    private UIInventory _uiInventory;

    private void Awake()
    {
        _uiInventory = GetComponentInParent<UIInventory>();
    }

    public void SetSlot(IInventorySlot newSlot)
    {
        slot = newSlot;
    }

    public void Refresh()
    {
        if (slot != null)
        {
            _uiInventoryItem.Refresh(slot);
        }
    }
}
