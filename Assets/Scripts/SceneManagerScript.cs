using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenue");
    }

    public void LoadSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenue");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
