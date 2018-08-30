using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour {

    public float repulsingForce = 16.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if coming from the top side
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Rigidbody2D body = collision.collider.GetComponent<Rigidbody2D>();

            // Does the colliding object have a rigid body?
            if (body != null)
            {
                Vector2 velocity = body.velocity;
                velocity.y = repulsingForce;
                body.velocity = velocity;
            }
        }
    }
}
