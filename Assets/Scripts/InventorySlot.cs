using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Sprite deselectedSprite, selectedSprite;
    private Image image;

    public void Awake() {
        image = GetComponent<Image>();
        Deselect();
    }

    public void Select() {
        image.sprite = selectedSprite;
    }

    public void Deselect() {
        image.sprite = deselectedSprite;
    }

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggable = dropped.GetComponent<InventoryItem>();
            if (draggable != null) {
                draggable.parentAfterDrag = this.transform;
            }            
        }
    }
}
