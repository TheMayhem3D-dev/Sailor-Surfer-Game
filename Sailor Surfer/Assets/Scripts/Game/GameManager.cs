using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    [Header("General")]
    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get => playerController; }

    [SerializeField] private GameStateManager gameStateManager;
    public GameStateManager GetGameStateManager { get => gameStateManager; }

    [SerializeField] private AudioManager audioManager;
    public AudioManager AudioManager { get => audioManager; }

    [SerializeField] private UIManager uiManager;
    public UIManager UIManager { get => uiManager; }


    [Header("Items")]
    public int coins = 0;
    public int boxes = 1;
}
