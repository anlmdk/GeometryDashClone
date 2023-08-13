using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehaviour : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            SpikeMovement();
        }
    }
    void SpikeMovement()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.menuPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Death();
        }
    }
}
