using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Har inte gjort tester f�r PlayerMovement eftersom jag tycker det �r mest logiskt att testa movment i sj�lva spelet.
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public LayerMask groundLayer;
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
        // Tar input fr�n anv�ndaren f�r att r�ra sig h�ger eller v�nster.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Spelarens r�relser
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // V�nder spelaren n�r den r�r sig h�ger eller v�nster
        Direction(horizontalInput);

        // Resets canDoubleJump n�r isGrounded �r true
        if (IsGrounded())
        {
            canDoubleJump = true;
        }

        // Input av spelaren f�r hopp
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

       // Spelaren hoppar automatiskt om den tr�ffar en Enemy
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
    /// Metod f�r att f� Player att hoppa
    /// </summary>
    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        animator.SetTrigger("Jump");
    }

    /// <summary>
    /// V�nder Player �t r�tt h�ll beroende p� spelarens input
    /// </summary>
    /// <param name="horizontalInput">Spelarens input (H�ger, V�nster)</param>
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
    /// Kollar om Player st�r p� Ground
    /// </summary>
    /// <returns>true om spelar st�r p� Ground</returns>
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
