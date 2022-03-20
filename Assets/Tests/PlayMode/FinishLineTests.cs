using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class FinishLineTests
{
    [UnityTest]
    public IEnumerator CheckwonGameMenuIsActive_wonLevelTrue_IsActive()
    {
        var gameObject = new GameObject();
        var finishLine = gameObject.AddComponent<FinishLine>();
        var WonTime = gameObject.AddComponent<Text>();
        finishLine.WonTime = WonTime;
        var wonGameMenu = gameObject;
        finishLine.wonGameMenu = wonGameMenu;
        
        finishLine.gameObject.SetActive(false);
        finishLine.wonLevel = true;
        finishLine.CheckPlayerWonLevel();
       
        yield return null;
        
        Assert.IsTrue(finishLine.wonGameMenu.activeInHierarchy); 
    }

    [UnityTest]
    public IEnumerator CheckwonGameMenuIsActive_wonLevelFalse_IsNotActive()
    {
        var gameObject = new GameObject();
        var finishLine = gameObject.AddComponent<FinishLine>();
        var WonTime = gameObject.AddComponent<Text>();
        finishLine.WonTime = WonTime;
        var wonGameMenu = gameObject;
        finishLine.wonGameMenu = wonGameMenu;

        finishLine.gameObject.SetActive(false);
        finishLine.wonLevel = false;
        finishLine.CheckPlayerWonLevel();

        yield return null;

        Assert.IsFalse(finishLine.wonGameMenu.activeInHierarchy);
    }
}
