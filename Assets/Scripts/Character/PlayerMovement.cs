using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    public GameObject originPositionsObject;

	[Space]
	[Header("Movement")]

	// player state floats
	public float runSpeed = 80f;
	public float horizontalMove = 0f;
	public float slideSpeed = 5;
	public float wallJumpLerp = 10;

	[Space]
	[Header("Booleans")]

	// player state booleans
	public bool jump = false;
	public bool crouch = false;
	public bool wallGrab = false;
	public bool wallJump = false;
	public bool wallSlide = false;

    void Start()
    {
		// left = true;
		// animator.SetBool("facingLeft", true);
        animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {

		controller.Move(horizontalMove * Time.deltaTime, crouch, jump);

		// get horzontal movement times runspeed
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		// jump check
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		} 
		else 
		{
			jump = false;
		}

		// crouch check
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	    // falling check
		if (controller.Falling())
		{
			animator.SetBool("IsFalling", true);
		}
		else
		{
			animator.SetBool("IsFalling", false);
		}
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate () {

		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

	}
}
