using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    START,
    GAME,
    FINISH,
    DEFEAT
}

public class GameStateManager : MonoBehaviour
{
    private void Start()
    {
        ChangeGameState(GameState.START);
    }

    public void ChangeGameState(GameState value)
    {
        switch (value)
        {
            case GameState.START:
                GameManager.instance.UIManager.ShowTutorial(true);
                GameManager.instance.PlayerController.EnablePlayer(false);
                break;

            case GameState.GAME:
                GameManager.instance.PlayerController.EnablePlayer(true);
                break;

            case GameState.FINISH:
                GameManager.instance.UIManager.ShowWinScreen(true);
                GameManager.instance.PlayerController.EnablePlayer(false);
                GameManager.instance.PlayerController.PlayerAnimator.SetTrigger("Win");
                break;

            case GameState.DEFEAT:
                GameManager.instance.UIManager.ShowDefeatScreen(true);
                GameManager.instance.PlayerController.EnablePlayer(false);
                GameManager.instance.PlayerController.PlayerAnimator.SetTrigger("Defeat");
                break;

            default:
                break;
        }
    }

    public void StartGame()
    {
        ChangeGameState(GameState.GAME);
    }
}
