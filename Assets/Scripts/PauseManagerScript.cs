using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // UI to show/hide during pause
    public bool isPaused = false; // Boolean to track pause state

    private void Awake()
    {
        // Ensures there is only one instance of PauseManager in the game
        if (FindObjectsOfType<PauseManagerScript>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    private void Update()
    {
        // Check for the pause input (e.g., Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game (stop time)
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game (restore time)
        isPaused = false;
    }

    public void Restart()
    {
        // Restart the current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
