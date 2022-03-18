using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Sätter igång spelet från huvudmenyn.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Stänger av applikationen.
    /// </summary>
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
