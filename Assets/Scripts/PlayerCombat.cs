using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public int PlayerHitpoints = 100;
    public Animator animator;
    public Text hitpointsUI;
    public GameObject DeadMenu;
    public static bool collisionEnemy;
   

    void Update()   
    {

        HitByEnemy();

        if (isDead())
        {
            animator.SetTrigger("Death");
            Invoke("GameOver", 0.5f);
        }

        hitpointsUI.text = "HP: " + PlayerHitpoints;
    }
    

    /// <summary>
    /// Känner av ifall spelaren kolliderar med en enemy
    /// </summary>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collisionEnemy = true;
        }
    }

    /// <summary>
    /// Kollar ifall spelaren har kolliderat med en enemy och isåfall förlorar HitPoints
    /// </summary>
    public void HitByEnemy()
    {
        if (collisionEnemy)
        {
            PlayerHitpoints = PlayerHitpoints - EnemyScript.enemyAttack;
        }
        else return;
    }

    /// <summary>
    /// Kollar om spelaren är död
    /// </summary>
    public bool isDead()
    {
        if(PlayerHitpoints == 0) return true;
        else return false;
    }

    /// <summary>
    /// sätter igång GameOver menyn.
    /// </summary>
    public void GameOver()
    {
        DeadMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
