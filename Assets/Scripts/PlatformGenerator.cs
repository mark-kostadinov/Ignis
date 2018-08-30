using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject finalPlatform;

    // Some arbitrary values
    public int numPlatforms = 1000;
    public float levelWidth = 4.0f;
    public float minY = 0.5f;
    public float maxY = 2.5f;

    public float finalPlatformPosY;

	void Start () {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numPlatforms; i++)
        {
            // Generate a random position for our platform in the given range
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            // Generate the platform itself
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            // Get the appropriate position for the final platform
            if (i == numPlatforms - 1)
            {
                finalPlatformPosY = spawnPosition.y - 1.0f;
            }
        }
        // Generate the final platform
        Vector3 finalPlatformPos = new Vector3(0, finalPlatformPosY, 0);
        finalPlatform.SetActive(true);
        finalPlatform.transform.Translate(finalPlatformPos);
    }
}
