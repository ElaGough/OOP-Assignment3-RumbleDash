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

    private Animator anim;

    public GameObject ball;
    public Transform throwPoint;

    public AudioSource throwSound;

	//when player is in contatct with enemies
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	public bool knockFromLeft;


	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

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

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(throwBall))
        {
            GameObject ballClone = (GameObject)Instantiate(ball, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            throwSound.Play();
        }

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
		while (other.tag == "Enemy" && tag == "Player1" && isGrounded == false)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			FindObjectOfType<GameManager> ().HurtP1 ();
			yield return new WaitForSeconds (1);

		}
		while (other.tag == "Enemy" && tag == "Player2" && isGrounded == false)
		{
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			FindObjectOfType<GameManager> ().HurtP2 ();
			yield return new WaitForSeconds (1);

		}
	}
}
