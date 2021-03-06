﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    private Rigidbody2D theRB; //the RB => the rigidbody

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

	private bool doubleJumped;

    private Animator anim;

    public GameObject ball;
    public Transform throwPoint;

    public AudioSource throwSound;


	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//player jumping
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if (isGrounded)
			doubleJumped = false;
		
		if (Input.GetKeyDown(jump) && isGrounded)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}
		if (Input.GetKeyDown (jump) && !doubleJumped && !isGrounded) {
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			doubleJumped = true;
		}

		//player moving left and right
		if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
			
		//player shooting
        if (Input.GetKeyDown(throwBall))
        {
            GameObject ballClone = (GameObject)Instantiate(ball, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            throwSound.Play();
        }

		//turning animation
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" && tag == "Player1")
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			FindObjectOfType<GameManager> ().HurtP1 ();
			yield return new WaitForSeconds (1);

		}
		if (other.tag == "Enemy" && tag == "Player2")
		{
			theRB.velocity = new Vector2(moveSpeed, jumpForce);
			FindObjectOfType<GameManager> ().HurtP2 ();
			yield return new WaitForSeconds (1);

		}
	}
}
