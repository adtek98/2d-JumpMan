using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public bool wonLevel = false;
    public Text WonTime;
    public GameObject wonGameMenu;
    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        
        CheckPlayerWonLevel();
    }


    /// <summary>
    /// Metod för göra om tiden till ett snyggare format {00:00}
    /// </summary>
    private string NicerTimer(float timer)
    {
        int Minutes = Mathf.FloorToInt(timer / 60);
        int Seconds = Mathf.FloorToInt(timer % 60);
        string Time = string.Format("{0:00}:{1:00}", Minutes, Seconds);

        return Time;
    }

    /// <summary>
    /// Kollar ifall Player kolliderar med Finishline
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wonLevel = true;
        }

    }

    /// <summary>
    /// Kollar ifall Player har vunnit nivån eller inte
    /// </summary>
    public void CheckPlayerWonLevel()
    {
        if (wonLevel)
        {
            WonTime.text = NicerTimer(timer) + " minutes!";
            Time.timeScale = 0f;
            wonGameMenu.SetActive(true);
            wonLevel = false;
        }
        else return;
    }
}
