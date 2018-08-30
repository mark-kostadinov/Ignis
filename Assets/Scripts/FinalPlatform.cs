using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class FinalPlatform : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject victoryMenuUI;

    void Start()
    {
        // Hide the victory screen by default
        victoryMenuUI.SetActive(false);
    }

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
                // Freeze player movement
                Player.freezeMovement = true;

                // Bring up the victory screen
                victoryMenuUI.SetActive(true);

                BackgroundMusic.stopMusic = true;
                PlayVictorySound();

                Debug.Log("Player won!");
                StartCoroutine(EndGame());
            }
        }
    }

    void PlayVictorySound()
    {
        audioSource.Play();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5.0f);

        // Go back to the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        // Unfreeze player movement
        Player.freezeMovement = false;
    }
}
