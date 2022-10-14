using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWithSlots : IInventory
{
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemoveEvent;
    public event Action<object> OnInventoryStateChangetEvent;

    public int capacity { get; set; }

    public bool IsFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots;

    public InventoryWithSlots(int capacity)
    {
        this.capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem[] GetAllItems()
    {
       var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
            {
                allItems.Add(slot.item);
            }
        }
        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in slotsOfType)
        {
            allItemsOfType.Add(slot.item);
        }
        return allItemsOfType.ToArray();
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).item;
    }

    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotWithItem = GetAllSlots(itemType);
        if (slotWithItem.Length == 0)
        {
            return;
        }
        var amountToRemove = amount;
        var count = slotWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotWithItem[i];
            if (slot.amount >= amountToRemove)
            {
                slot.item.state.amount -= amountToRemove;
                if (slot.amount <= 0)
                {
                    slot.Clear();
                    OnInventoryItemRemoveEvent?.Invoke(sender, itemType, amountToRemove);
                    OnInventoryStateChangetEvent?.Invoke(sender);
                    break;
                }
            }
            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount;
            slot.Clear();
            OnInventoryItemRemoveEvent?.Invoke(sender, itemType, amountToRemove);
            OnInventoryStateChangetEvent?.Invoke(sender);
        }
    }

    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.Find(slot => !slot.isEmpty && slot.itemType == item.type && !slot.isFull);
        if (slotWithSameItemButNotEmpty != null)
        {
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);
        }
        var emptySlot = _slots.Find(slot => slot.isEmpty);
        if (emptySlot != null)
        {
            return TryToAddToSlot(sender, emptySlot, item);
        }
        Debug.Log($"Cannot add item ({item.type}), amount: {item.state.amount}, because there is no place for that.");
        return false;
    }
    private bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.state.amount <= item.info.MaxItemsInInventorySlot;
        var amountToAdd = fits ? item.state.amount : item.info.MaxItemsInInventorySlot - slot.amount;
        var amountLeft = item.state.amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.state.amount = amountToAdd;
        if (slot.isEmpty)
        {
            slot.SetItem(clonedItem);
        }
        else
        {
            slot.item.state.amount += amountToAdd;
        }
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangetEvent?.Invoke(sender);
        if (amountLeft <= 0)
        {
            return true;
        }
        item.state.amount = amountLeft;
        return TryToAdd(sender,item);
    }

    public int GetItemAmount(Type itemType)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var itemSlot in allItemSlots)
        {
            amount += itemSlot.amount;
        }
        return amount;
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }
}
