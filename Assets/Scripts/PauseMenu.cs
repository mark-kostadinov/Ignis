using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        // Bring up the Pause menu
        pauseMenuUI.SetActive(true);
        // Freeze time in the game
        Time.timeScale = 0.0f;
        // Freeze player movement
        Player.freezeMovement = true;

        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        // Close the Pause menu
        pauseMenuUI.SetActive(false);
        // Unfreeze time in the game
        Time.timeScale = 1.0f;
        // Unfreeze player movement
        Player.freezeMovement = false;

        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Game terminated successfully!");
        Application.Quit();
    }
}
