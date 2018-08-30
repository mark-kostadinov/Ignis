using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NitrogenPlatform : MonoBehaviour
{
    public float repulsingForce = 20.0f;
    AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if coming from the top side
        if (collision.relativeVelocity.y <= 0.0f)
        {
            Rigidbody2D body = collision.collider.GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

            // Does the colliding object have a rigid body?
            if (body != null)
            {
                Vector2 velocity = body.velocity;
                velocity.y = repulsingForce;
                body.velocity = velocity;

                PlayJumpSound();

                BurnDown();
            }
        }
    }

    void PlayJumpSound()
    {
        audioSource.Play();
    }

    void BurnDown()
    {
        // If our flame drop steps on the platform - destroy it after a given time period
        Destroy(gameObject, 1.5f);
    }
}
