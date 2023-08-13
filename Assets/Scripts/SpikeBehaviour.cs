using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehaviour : MonoBehaviour
{
    public float speed = 5f;

    public bool death = false;
    public bool restart = false;

    // Sahne yeniden yüklendiðinde çaðrýlacak olan metot
    void Start()
    {
        if (!restart)
        {
            GameManager.instance.gameStarted = true;
            GameManager.instance.menuPanel.SetActive(false);
        }
    }
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
        if (!death)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            restart = true;
        }
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
