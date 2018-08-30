using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Boundaries : MonoBehaviour {

    Rigidbody2D playerBody;
    AudioSource audioSource;
    public GameObject defeatMenuUI;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerBody = collision.collider.GetComponent<Rigidbody2D>();

        // Has the player caused the collision?
        if (playerBody != null)
        {
            // Freeze player movement
            Player.freezeMovement = true;

            // Bring up the defeat screen
            defeatMenuUI.SetActive(true);

            BackgroundMusic.stopMusic = true;
            PlayDefeatSound();

            StartCoroutine(EndRun());

            Debug.Log("Player lost.");
        }
    }

    void PlayDefeatSound()
    {
        audioSource.Play();
    }

    IEnumerator EndRun()
    {
        yield return new WaitForSeconds(4.0f);

        // Go back to the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        // Freeze player movement
        Player.freezeMovement = false;
    }
}
