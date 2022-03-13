using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Diamond;
    Vector3 LastPos;
    float size;
    public bool Gameover;

    void Start()
    {
        LastPos = Platform.transform.position;
        size = Platform.transform.localScale.x;
        for (int i = 0; i < 5; i++)
        {
            PlatFormSpawn();
        }      
    }

    public void StartPlatformSpawn()
    {
        InvokeRepeating("PlatFormSpawn", 2f, 0.2f); 
    }
    
    void Update()
    {
        if (GameMaanager.instance.gameOver == true)
            CancelInvoke("PlatFormSpawn");
    }

    void PlatFormSpawn()
    {
        int n = Random.Range(0, 5);

        if (n < 3)
            SpawnX();
        else if (n >= 3)
            SpawnZ();
    }

    void SpawnX()
    {
        Vector3 Pos = LastPos;
        Pos.x += size;
        LastPos = Pos;

        Instantiate(Platform, LastPos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(Diamond, new Vector3(Pos.x, Pos.y + 1, Pos.z), Diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        LastPos.z += size;

        Vector3 Pos = LastPos;

        Instantiate(Platform, LastPos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(Diamond, new Vector3(Pos.x, Pos.y + 1, Pos.z), Diamond.transform.rotation);
        }
    }
}
