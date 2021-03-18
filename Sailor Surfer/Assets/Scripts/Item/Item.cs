using UnityEngine;

public enum ItemType
{
    BOX,
    COIN,
    FINISH,
    ENEMY,
    TURN
}

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType = ItemType.BOX;
    public ItemType ItemType { get => itemType; }

    [SerializeField] private int count = 1;
    public int Count { get => count; }
}
