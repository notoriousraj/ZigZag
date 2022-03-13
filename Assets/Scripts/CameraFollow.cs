using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    private void Start()
    {
        offset = ball.transform.position - transform.position;
    }

    private void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 TargetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, TargetPos, lerpRate);
        transform.position = pos;
    }
}
