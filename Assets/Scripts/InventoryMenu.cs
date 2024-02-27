using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{

    public static bool InvIsOpen = false;
    public GameObject inventoryMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused) return;
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(InvIsOpen ? "Closing inventory" : "Opening inventory");
            if (InvIsOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }

    public void CloseInventory()
    {
        inventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        InvIsOpen = false;
    }

    void OpenInventory()
    {
        inventoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InvIsOpen = true;
    }
}
