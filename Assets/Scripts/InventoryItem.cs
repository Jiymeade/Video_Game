using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public TextMeshProUGUI amountText;

    [HideInInspector] public Item item;
    [HideInInspector] public int amount = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void Start() {
        InitializeItem(item);
    }

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.image;
        RefreshAmount();
    }

    public void RefreshAmount()
    {
        amountText.text = amount.ToString();
        bool isAmountVisible = amount > 1;
        amountText.gameObject.SetActive(isAmountVisible);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        image.raycastTarget = false;    
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
