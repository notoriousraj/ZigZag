using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControle : MonoBehaviour
{
    public GameObject Partical;

    [SerializeField]
    float speed;
    bool Started;
    bool GameOver;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameOver = false;
        Started = false;
    }

    private void Update()
    {
        //Making the ball move
        if (!Started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                Started = true;

                GameMaanager.instance.GameStart();
            }
        }
        else if(Started)
        {
            if (Input.GetMouseButtonDown(0) && !GameOver)
            {
                SwitchDirection();
            }
        }

        //Making the Ball fall
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            rb.velocity = new Vector3(0, -25, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameMaanager.instance.GameOver();
        }
    }

    //Used to switch directions
    void SwitchDirection()
    {
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    //Ball destroy
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(Partical, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
        }
    }
}
