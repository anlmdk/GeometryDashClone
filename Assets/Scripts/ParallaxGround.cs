using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGround : MonoBehaviour
{
    public float parallaxSpeed = 0.5f;
    public float resetPosition = -10f; // Zemin sýnýra geldiðinde resetlenecek pozisyon
    public Transform secondGround;     // Ýkinci zemin nesnesi

    void Update()
    {
        if (GameManager.gameStarted)
        {
            ParallaxMovement();
        }
    }
    void ParallaxMovement()
    {
        float moveAmount = parallaxSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * moveAmount);

        // Zemin sýnýra geldiðinde resetle
        if (transform.position.x <= resetPosition)
        {
            float offset = secondGround.position.x - transform.position.x;
            transform.position = new Vector3(secondGround.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
