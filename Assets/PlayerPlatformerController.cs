
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 100f;
    public float jumpTakeOffSpeed = 100f;
    public float climbingSpeed = 30f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isLadder;

    // Use this for initialization
    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
            animator.SetFloat ("velocityY", Mathf.Abs (velocity.y) / jumpTakeOffSpeed);

        } else if (Input.GetButtonUp ("Jump"))
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (Input.GetButtonDown ("Vertical") && isLadder)
        {
            velocity.y = climbingSpeed;
            //climbing = true;
            animator.SetBool("climbing", true);

        } else if (Input.GetButtonUp ("Vertical") && isLadder)
        {
            //velocity.y = velocity.y * 0;
            //Physics2D.gravity = new Vector2(0, 0f);

            Debug.Log("On the ladder");

        } else if (Input.GetButtonUp ("Vertical") && !isLadder)
        {
            Debug.Log("Nerd");
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) //If enter ladder collision
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //If exit ladder collision
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            animator.SetBool("climbing", false);
        }
    }
}
