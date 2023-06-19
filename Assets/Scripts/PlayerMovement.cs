using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    Rigidbody2D rb;
    Vector2 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        Vector2 movement = movementInput * movementSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }
}
