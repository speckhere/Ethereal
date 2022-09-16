using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool right = false;
    bool left = false;
    
    private Vector2 pos;
    public float startPos;

    public GameObject originPositionsObject;

    void Start()
    {
		// left = true;
		// animator.SetBool("facingLeft", true);
        animator = GetComponent<Animator>();

        startPos = pos.x;
    }

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (controller.Falling()) {
			animator.SetBool("IsFalling", true);
			Debug.Log("Falling");
		}

		//ChasingTheString
		//float currentPos = transform.position.x;

        //if(currentPos > startPos)
        //{
            // right
        //    right = true;
		//	animator.SetBool("facingR", true);
            
        //}
        //else if(currentPos < startPos) 
        //{
            // left
        //    left = true;
		//	animator.SetBool("facingLeft", true);

        //}
        //startPos = currentPos;

	}

	public void OnLanding () 
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		//Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
