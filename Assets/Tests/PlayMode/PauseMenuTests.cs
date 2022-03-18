using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void PauseMenuTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PauseMenuTestsgea()
    {
        var gameObject = new GameObject();
        var playerScore = gameObject.AddComponent<PlayerScore>();

        float timer =+ Time.deltaTime;
        yield return new WaitForSeconds(2f);

        Assert.AreEqual("00:02", playerScore.NicerTimer(timer));
    }
}
