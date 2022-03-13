using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaanager : MonoBehaviour
{
    public static GameMaanager instance;
    public bool gameOver = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameStart()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.startscore();
        GameObject.Find("FlatformSpawn").GetComponent<PlatForm>().StartPlatformSpawn();
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
       
        gameOver = true;
    }
}
