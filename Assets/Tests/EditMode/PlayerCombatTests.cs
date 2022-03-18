using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerCombatTests
{
    
    [Test]
    public void IsDead_0hitpoints_returnTrue()
    {
        GameObject gameObject = new GameObject();
        PlayerCombat playerCombat = gameObject.AddComponent<PlayerCombat>();
        
        playerCombat.PlayerHitpoints = 0;

        Assert.IsTrue(playerCombat.isDead());

    }

    [Test]
    public void IsDead_25hitpoints_returnFalse()
    {
        GameObject gameObject = new GameObject();
        PlayerCombat playerCombat = gameObject.AddComponent<PlayerCombat>();

        playerCombat.PlayerHitpoints = 25;

        Assert.IsFalse(playerCombat.isDead());

    }



}
