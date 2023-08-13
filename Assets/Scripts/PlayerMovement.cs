using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
        }
    }
    void Move()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
