using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayerCombatTests
{

    [UnityTest]
    public IEnumerator CheckPlayerIsDead_75HitPoints_PlayerDeadIsFalse()
    {
        var gameObject = new GameObject();
        var playerCombat = gameObject.AddComponent<PlayerCombat>();
        var hitpointsUI = gameObject.AddComponent<Text>();
        playerCombat.hitpointsUI = hitpointsUI;

        playerCombat.PlayerHitpoints = 75;
        
        yield return null;

        Assert.IsFalse(playerCombat.isDead());
    }

    [UnityTest]
    public IEnumerator CheckPlayerIsDead_0HitPoints_PlayerDeadIsTrue()
    {
        var gameObject = new GameObject();
        var playerCombat = gameObject.AddComponent<PlayerCombat>();
        var hitpointsUI = gameObject.AddComponent<Text>();
        playerCombat.hitpointsUI = hitpointsUI;
        var animator = gameObject.AddComponent<Animator>();
        playerCombat.animator = animator;


        playerCombat.PlayerHitpoints = 0;

        yield return null;

        Assert.IsTrue(playerCombat.isDead());
    }

    [UnityTest]
    public IEnumerator CheckPlayerHitpointsWhenHitByEnemy_100HitPoints_75HitpointsWhenHit()
    {
        var gameObject = new GameObject();
        var playerCombat = gameObject.AddComponent<PlayerCombat>();
        var hitpointsUI = gameObject.AddComponent<Text>();
        playerCombat.hitpointsUI = hitpointsUI;


        playerCombat.PlayerHitpoints = 100;
        PlayerCombat.collisionEnemy = true;
        playerCombat.HitByEnemy();
        PlayerCombat.collisionEnemy = false;

        yield return null;

        Assert.AreEqual(75, playerCombat.PlayerHitpoints);
    }
}
