using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;

    public float jumpPower = 26f;
    public float rotationAngle = 180f; // Dönme açýsý
    public float rotationDuration = 0.3f; // Dönme süresi
    private Quaternion targetRotation; // Dönme açýsý

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
        if(GameManager.instance.gameStarted)
        {
            if (Input.GetMouseButton(0) && rb.velocity.y <= 0f )
            {
                Jump();
            }
        }
    }
    void Jump()
    {
        if (OnGround() && !isRotating)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);

            StartCoroutine(RotateCharacter());
        }
    }
    bool OnGround()
    {
        return Physics2D.OverlapBox(groundCheckTransform.position, Vector2.right * 1.1f + Vector2.up * groundCheckRadius, groundCheckLayerMask);
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
