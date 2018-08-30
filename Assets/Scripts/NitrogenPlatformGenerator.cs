using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitrogenPlatformGenerator : MonoBehaviour {

    public GameObject platformPrefab;

    // Some arbitrary values
    public int numPlatforms = 50;
    public float levelWidth = 4.0f;
    public float minY = 30.0f;
    public float maxY = 40.0f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numPlatforms; i++)
        {
            // Generate a random position for our platform in the given range
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            // Generate the platform itself
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
