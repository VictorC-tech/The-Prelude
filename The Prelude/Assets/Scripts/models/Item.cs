using UnityEngine;


public enum SlotTag
{
    None,
    Weapon,
    Armor,
    Consumable
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;

}
