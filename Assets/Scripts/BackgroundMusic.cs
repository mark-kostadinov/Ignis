using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public static bool stopMusic = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource.isPlaying && stopMusic)
        {
            audioSource.Stop();

            StartCoroutine(Wait());

            stopMusic = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.1f);

        audioSource.Play();
    }
}
