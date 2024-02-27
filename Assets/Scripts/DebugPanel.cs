using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public List<GameObject> pages;
    [HideInInspector] public int currentPageIndex = 0;

    public void Start()
    {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[currentPageIndex].SetActive(true);
    }

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("No space");
        }
    }

    public void NextPage() {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        currentPageIndex = (currentPageIndex + 1) % pages.Count;
        Debug.Log("Current page: " + pages[currentPageIndex]);
        pages[currentPageIndex].SetActive(true);
    }

    public void PreviousPage() {
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }
        currentPageIndex--;
        if (currentPageIndex < 0) {
            currentPageIndex = pages.Count - 1;
        }
        Debug.Log("Current page: " + pages[currentPageIndex]);
        pages[currentPageIndex].SetActive(true);
    }
}
