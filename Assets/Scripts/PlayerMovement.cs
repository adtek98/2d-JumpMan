using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool canDoubleJump;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Tar input från användaren för att röra sig höger eller vänster.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Spelarens rörelser
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Vänder spelaren när den rör sig höger eller vänster
        Direction(horizontalInput);

        // Resets canDoubleJump när isGrounded är true
        if (IsGrounded())
        {
            canDoubleJump = true;
        }

        // Input av spelaren för hopp
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {
                Jump();
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    if(canDoubleJump == true)
                    {
                        Jump();
                        canDoubleJump = false;
                    }
                }
            }
        }

       // Spelaren hoppar automatiskt om den träffar en Enemy
        if (PlayerCombat.collisionEnemy == true)
        {
            Jump();
            PlayerCombat.collisionEnemy = false;
        }

        // Aktiverar animationer
        animator.SetBool("Run", horizontalInput != 0);
        animator.SetBool("Grounded", IsGrounded());

    }

    /// <summary>
    /// Metod för att få spelaren att hoppa
    /// </summary>
    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        animator.SetTrigger("Jump");
    }

    /// <summary>
    /// Vänder spelaren åt rätt håll beroende på spelarens input
    /// </summary>
    /// <param name="horizontalInput">Spelarens input (Höger, Vänster)</param>
    public void Direction(float horizontalInput)
    {
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    /// <summary>
    /// Håller koll på om spelaren står på marken
    /// </summary>
    /// <returns>true om spelar står på marken</returns>
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
