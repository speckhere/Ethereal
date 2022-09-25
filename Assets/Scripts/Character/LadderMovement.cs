using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{

    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    bool up = false;
    private bool isClimbing;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && up)
        {
            isClimbing = true;
            animator.SetBool("IsClimbing", true);
            Debug.Log ("Going up!");
        }  else if (!isLadder)
        {
            animator.SetBool("IsClimbing", false);
        }

        if (Input.GetButtonDown("Vertical"))
		{
			up = true;
		} else if (Input.GetButtonUp("Vertical"))
		{
			up = false;
		}
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 3.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}
