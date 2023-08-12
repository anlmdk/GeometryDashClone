using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }
    void Update()
    {
        SpikeMovement();
    }
    void SpikeMovement()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
