using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MenuScriptsTests
{
    [UnityTest]
    public IEnumerator PauseMenuTest_IsPausedTrue_PauseMenuIsActive()
    {
        var gameObject = new GameObject();
        var menuScripts = gameObject.AddComponent<MenuScripts>();
        var pauseMenu = gameObject;
        menuScripts.pauseMenu = pauseMenu;

        menuScripts.pauseMenu.SetActive(false);
        menuScripts.isPaused = false;
        menuScripts.PauseOrResumeGame();

        yield return null;

        Assert.IsTrue(menuScripts.pauseMenu.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator PauseMenuTest_IsPausedFalse_PauseMenuIsNotActive()
    {
        var gameObject = new GameObject();
        var menuScripts = gameObject.AddComponent<MenuScripts>();
        var pauseMenu = gameObject;
        menuScripts.pauseMenu = pauseMenu;

        menuScripts.pauseMenu.SetActive(true);
        menuScripts.isPaused = true;
        menuScripts.PauseOrResumeGame();

        yield return null;

        Assert.IsFalse(menuScripts.pauseMenu.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator RestartGameTest_()
    {
        var gameObject = new GameObject();
        var menuScripts = gameObject.AddComponent<MenuScripts>();

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        menuScripts.RestartGame();
        yield return null;

        Assert.AreEqual(buildIndex, SceneManager.GetActiveScene().buildIndex);
    }


    [UnityTest]
    public IEnumerator QuitTest_()
    {
        var gameObject = new GameObject();
        var menuScripts = gameObject.AddComponent<MenuScripts>();

        int buildIndex = SceneManager.GetActiveScene().buildIndex - 1;

        menuScripts.Quit();
        yield return null;

        Assert.AreEqual(buildIndex, SceneManager.GetActiveScene().buildIndex);
    }

}
