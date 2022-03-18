using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public int PlayerHitpoints = 100;
    private Animator animator;
    public GameObject hitpointsUI;
    public GameObject DeadMenu;
    public static bool collisionEnemy;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Attack fungerar endast visuellt just nu
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Attack();
        //}

        if (collisionEnemy)
        {
            PlayerHitpoints = PlayerHitpoints - EnemyScript.enemyAttack;
        }


        if (isDead())
        {
            animator.SetTrigger("Death");
            Invoke("GameOver", 0.5f);
        }

        hitpointsUI.GetComponent<Text>().text = "HP: " + PlayerHitpoints;
    }
    

    //metod för attack, inte färdig
    //void Attack()
    //{
    //    animator.SetTrigger("Attack");
    //}

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

    public bool isDead()
    {
        if(PlayerHitpoints == 0) return true;
        else return false;
    }

    /// <summary>
    /// GameOver metod nör spelaren dör
    /// </summary>
    public void GameOver()
    {
        DeadMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
