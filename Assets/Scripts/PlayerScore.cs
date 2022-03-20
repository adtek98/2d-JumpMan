using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text timerUI;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        // Uppdaterar tiden i PlayerUI
        timerUI.text = NicerTimer(timer);
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


}
