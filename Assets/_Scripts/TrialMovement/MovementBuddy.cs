using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MovementBuddy : MonoBehaviour {

	public Transform traget;

	public float movementSpeed;
	public float jumpSpeed;
	float moveVelocity;

	private bool grounded = false;

	private Rigidbody2D buddy;

	// Use this for initialization
	void Start ()
    {
        buddy = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        //Jumping is cool
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded == true)
            {
                buddy.velocity = new Vector2(buddy.velocity.x, jumpSpeed); //2D x axis and y axis
            }
        }

        //Moving
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity -= movementSpeed; //taking movementSpeed from moveVelocity (going RIGHT)
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity += movementSpeed; //adding movementSpeed to moveVelocity (going LEFT)
        }

        buddy.velocity = new Vector2(moveVelocity, buddy.velocity.y); //jumping doesn't get effected by movement left and right
        moveVelocity = 0; //stops from speeding up
    }

    //check to see is player can jump (if on ground)
    void OnTriggerEnter2D (Collider2D col) //col => collider
    {
        if (col.gameObject.CompareTag ("Climbable"))
        {
            grounded = true;
        }
        else if (col.gameObject.CompareTag ("NotClimbable"))
        {
            grounded = false;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        grounded = false; //player has jumped so no longer grounded
    }
}
