using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    Vector2 movement;
    public float xMin, xMax, yMin, yMax;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y );
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
