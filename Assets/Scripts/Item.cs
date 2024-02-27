using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int size = new Vector2Int(1, 1);
    [Header("Only UI")]
    public bool isStackable = true;
    [Header("Both")]
    public Sprite image;
    
}

public enum ItemType
{
    Tool,
    Seed,
    Crop,
    Resource
}

public enum ActionType
{
    None,
    Mine,
    Axe,
    Water,
    Hoe,
    Melee,
    Fish
}