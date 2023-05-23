using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2;
    public float maxVelocity = 4;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * (Vector2.down + ((Random.value > 0.5f ? Vector2.left : Vector2.right) * 0.5f )  ).normalized;
    }

    private void FixedUpdate()
    {
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        rb.velocity = rb.velocity.normalized * speed;
        //Debug.Log(rb.velocity);
    }
}
