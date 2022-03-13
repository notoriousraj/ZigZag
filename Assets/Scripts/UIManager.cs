using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject StartPanel;
    public GameObject OverPanel;
    public GameObject TapText;
    public Text score;
    public Text HighScore1;
    public Text HighScore2;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        HighScore1.text = "High Score : " + PlayerPrefs.GetInt("highscore").ToString();
    }

    public void GameStart()
    {
        TapText.SetActive(false);
        StartPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        HighScore2.text = PlayerPrefs.GetInt("highscore").ToString();

        OverPanel.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
