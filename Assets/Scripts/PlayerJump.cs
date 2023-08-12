using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpPower = 26f;
    public float rotationAngle = 180f; // Dönme açýsý
    public float rotationDuration = 0.3f; // Dönme süresi
    private Quaternion targetRotation; // Dönme açýsý

    private bool isJumping = false;
    private bool isRotating = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Sabit saða dönme açýsý
        targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    void Update()
    {
        ClickMouseButton();
    }

    void ClickMouseButton()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameStarted)
        {
            Jump();
        }
    }
    void Jump()
    {
        if (isJumping && !isRotating)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);

            StartCoroutine(RotateCharacter());

            isJumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
    private IEnumerator RotateCharacter()
    {
        isRotating = true;

        Quaternion initialRotation = transform.rotation;
        Quaternion finalRotation = transform.rotation * targetRotation;

        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = finalRotation;
        isRotating = false;
    }
}
