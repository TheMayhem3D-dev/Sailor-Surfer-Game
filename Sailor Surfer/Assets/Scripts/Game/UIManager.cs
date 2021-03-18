using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Screens")]
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject defeatScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshCoinText()
    {
        if (GameManager.instance != null)
        {
            coinText.text = GameManager.instance.coins.ToString();
        }
    }

    public void ShowTutorial(bool value)
    {
        tutorialScreen.SetActive(value);
    }

    public void ShowWinScreen(bool value)
    {
        winScreen.SetActive(value);
    }

    public void ShowDefeatScreen(bool value)
    {
        defeatScreen.SetActive(value);
    }
}
