using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image _imageItem;
    [SerializeField] private Text _textAmount;

    public IInventoryItem item { get; set; }

    public void Refresh(IInventorySlot slot)
    {
        if (slot.isEmpty)
        {
            Cleanup();
            return;
        }
        item = slot.item;
        _imageItem.sprite = item.info.spriteIcon;
        _imageItem.gameObject.SetActive(true);

        var textAmountEnabled = slot.amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);
        if (textAmountEnabled)
        {
            _textAmount.text = $"x{slot.amount.ToString()}";
        }
    }

    private void Cleanup()
    {
        _imageItem.gameObject.SetActive(false);
        _imageItem.gameObject.SetActive(false);
    }
}
