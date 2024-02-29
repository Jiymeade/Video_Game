using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public GameObject toolbar;
    public int maxStackAmount = 99;

    int selectedSlot = -1;

    public void Start()
    {
        SelectSlot(0); // select first slot by default
    }

    public void Update() {
        int toolbarLength = toolbar.transform.childCount;
        if (Input.inputString.Length > 0) {
            int index = Input.inputString[0] == '0' ? 9 : Input.inputString[0] - '1'; // 0-9
            if (index >= 0 && index < toolbarLength) {
                SelectSlot(index);
            }
        }
    }

    public void SelectSlot(int index)
    {
        if (selectedSlot != -1)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        selectedSlot = index;
        inventorySlots[selectedSlot].Select();
    }

    public bool AddItem(Item item)
    {
        // stack check
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            bool isSameItem = itemInSlot != null && itemInSlot.item == item;
            bool isStackingItem = isSameItem && itemInSlot.item.isStackable && itemInSlot.amount < maxStackAmount;
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
