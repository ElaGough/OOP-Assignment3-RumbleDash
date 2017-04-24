using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MovementStela : MonoBehaviour
{

    public Transform traget;

    public float movementSpeed;
    public float jumpSpeed;
    float moveVelocity;

    private bool grounded = false;

    private Rigidbody2D stela;

    // Use this for initialization
    void Start()
    {
        stela = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping is cool
        if (Input.GetKey(KeyCode.W))
        {
            if (grounded == true)
            {
                stela.velocity = new Vector2(stela.velocity.x, jumpSpeed); //2D x axis and y axis
            }
        }

        //Moving
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity -= movementSpeed; //taking movementSpeed from moveVelocity (going RIGHT)
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity += movementSpeed; //adding movementSpeed to moveVelocity (going LEFT)
        }

        stela.velocity = new Vector2(moveVelocity, stela.velocity.y); //jumping doesn't get effected by movement left and right
        moveVelocity = 0; //stops from speeding up
    }

    //check to see is player can jump (if on ground)
    void OnTriggerEnter2D(Collider2D col) //col => collider
    {
        if (col.gameObject.CompareTag("Climbable"))
        {
            grounded = true;
        }
        else if (col.gameObject.CompareTag("NotClimbable"))
        {
            grounded = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        grounded = false; //player has jumped so no longer grounded
    }
}
