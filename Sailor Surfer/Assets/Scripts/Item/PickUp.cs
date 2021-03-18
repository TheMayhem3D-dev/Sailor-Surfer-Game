using UnityEngine;

[RequireComponent(typeof(Item))]
[RequireComponent(typeof(Trigger))]
[RequireComponent(typeof(Destroyer))]
public class PickUp : MonoBehaviour
{
    private Item item;
    private Destroyer destroyer;

    void Start()
    {
        item = GetComponent<Item>();
        destroyer = GetComponent<Destroyer>();
    }

    public void ItemPickUp()
    {
        if (GameManager.instance != null  && GameManager.instance.PlayerController != null)
        {
            if (item.ItemType == ItemType.BOX)
            {
                GameManager.instance.PlayerController.AddBoxes(item.Count);
                GameManager.instance.AudioManager.PlaySound(GameManager.instance.AudioManager.BoxPickUp);
            }
            else if (item.ItemType == ItemType.COIN)
            {
                GameManager.instance.PlayerController.AddCoins(item.Count);
                GameManager.instance.AudioManager.PlaySound(GameManager.instance.AudioManager.CoinPickUp);
            }
            else if (item.ItemType == ItemType.FINISH)
            {
                GameManager.instance.GetGameStateManager.ChangeGameState(GameState.FINISH);
            }
            else if (item.ItemType == ItemType.TURN)
            {
                Turn turn = GetComponent<Turn>();
                GameManager.instance.PlayerController.TurnPlayer(turn.TurnAngle, turn);
            }
            else if (item.ItemType == ItemType.ENEMY)
            {
                if (!GameManager.instance.PlayerController.Invulnerable.isInvulnerable)
                {
                    GameManager.instance.PlayerController.Invulnerable.isInvulnerable = true;

                    if (GameManager.instance.boxes <= item.Count)
                    {
                        GameManager.instance.GetGameStateManager.ChangeGameState(GameState.DEFEAT);
                    }

                    GameManager.instance.AudioManager.PlaySound(GameManager.instance.AudioManager.BoxDestroy);

                    GameManager.instance.PlayerController.SubtractBoxes(item.Count);
                }
            }
        }

        destroyer.Destroy(0f);
    }
}
