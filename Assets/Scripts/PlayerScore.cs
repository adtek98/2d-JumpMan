using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public GameObject timerUI;
    public GameObject playerScoreTime;
    public GameObject wonGameMenu;
    float timer = 0.0f;
    bool wonLevel;
    string wonLevelTime;

    

    void Update()
    {
        timer += Time.deltaTime;
        // Uppdaterar tiden i PlayerUI
        timerUI.GetComponent<Text>().text = NicerTimer(timer);

        // if statement om spelaren klarat av spelet.
        if (wonLevel)
        {
            wonLevelTime = NicerTimer(timer) + " minutes!";
            playerScoreTime.GetComponent<Text>().text = wonLevelTime;
            Time.timeScale = 0f;
            wonGameMenu.SetActive(true);
            wonLevel = false;
        }
    }

    /// <summary>
    /// Håller koll på när spelaren kommmer i mål.
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wonLevel = true;
        }
    }

    /// <summary>
    /// Gör om tiden i sekunder till ett snyggare format i minuter och sekunder.
    /// </summary>
    /// <param name="timer"></param>
    /// <returns></returns>
    public string NicerTimer(float timer)
    {
        int Minutes = Mathf.FloorToInt(timer/60);
        int Seconds = Mathf.FloorToInt(timer%60);
        string Time = string.Format("{0:00}:{1:00}", Minutes, Seconds);
        
        return Time;
    }
}
