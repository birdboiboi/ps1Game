using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{
    public float distToGround = 0;
    public float speed;
    public float jump;//Floating point variable to store the player's movement speed.
    //public bool jump = false;
    private Rigidbody rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private SpriteRenderer sr;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
       
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = -Input.GetAxis("Horizontal");
        sr.flipX = moveHorizontal > 0;
       
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical") * jump;

        moveVertical -= getDistGrounded();
        Debug.Log(IsGrounded() + "," + moveVertical);
        //Use the two store floats to create a new Vector2 variable movement.
        Vector3 movement = new Vector3(moveHorizontal * speed, moveVertical , 0);
        
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb.AddForce(transform.forward * speed);
        transform.Translate(movement *Time.deltaTime);
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    float getDistGrounded()
    {
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out hit))
        {
            return hit.distance;
        }
        else
        {
            return 0;
        }
        
        
    }
}
