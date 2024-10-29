using UnityEngine;

public enum SlotTag
{
    Weapon,
    Armor,
    Consumable
}
public class Item : ScriptableObject
{
    public Sprite _sprite;
    public SlotTag _itemTag;

}
