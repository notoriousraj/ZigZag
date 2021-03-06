using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    public void Increamentscore()
    {
        score += 1;
    }

    public void startscore()
    {
        InvokeRepeating("Increamentscore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("Increamentscore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highscore"))
        {
            if(score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
