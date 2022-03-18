using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// S�tter ig�ng spelet fr�n huvudmenyn.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// St�nger av applikationen.
    /// </summary>
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
