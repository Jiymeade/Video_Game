using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public int maxStackAmount = 99;
    public bool AddItem(Item item)
    {
        // stack check
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            bool isSameItem = itemInSlot != null && itemInSlot.item == item;
            Debug.Log("isSameItem: " + isSameItem);
            bool isStackingItem = isSameItem && itemInSlot.item.isStackable && itemInSlot.amount < maxStackAmount;
            Debug.Log("isStackingItem: " + isStackingItem);
            if (isStackingItem)
            {
                itemInSlot.amount++;
                itemInSlot.RefreshAmount();
                return true;
            }
        }
        // find empty slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public void SpawnItem(Item item, InventorySlot slot)
    {
        Debug.Log("SpawnItem");
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
