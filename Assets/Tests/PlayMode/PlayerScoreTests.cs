using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayerScoreTests
{

    [UnityTest]
    public IEnumerator TimerUITest_WaitFor2Seconds_0002()
    {
        var gameObject = new GameObject();
        var playerScore = gameObject.AddComponent<PlayerScore>();
        var timerUI = gameObject.AddComponent<Text>();
        playerScore.timerUI = timerUI;

        yield return new WaitForSeconds(2f);

        Assert.AreEqual("00:02", playerScore.timerUI.text);
    }

}
