using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementdeneme : MonoBehaviour
{
    public float moveSpeed = 5f; 

    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
}
