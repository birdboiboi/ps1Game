using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCobntroller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 tempMove;
    //private float windDrag = -3;
    public Transform cam;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //Vector3 move = new Vector3(-3, 0, 0);
        //Debug.Log(move);

        //controller.Move(move * Time.deltaTime * playerSpeed);
        transform.LookAt(cam);
        groundedPlayer = controller.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 normalDir = cam.position - transform.position;
        Vector3 move = new Vector3(0, -Input.GetAxis("Horizontal"), 0);
        move = Vector3.Cross(normalDir, move).normalized+ Vector3.Normalize(normalDir * Input.GetAxis("Vertical"));
        //Debug.Log(move);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
       
        // Changes the height position of the player..
        //bug.Log(groundedPlayer);
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log("jump");
            tempMove = move;
            Debug.Log(tempMove);

        }else if (!groundedPlayer)
        {
            normalDir = cam.position - transform.position;
            tempMove = new Vector3(0, -Input.GetAxis("Horizontal"), 0);
            tempMove = Vector3.Cross(normalDir, tempMove).normalized + Vector3.Normalize(normalDir * Input.GetAxis("Vertical"));
            Debug.Log(tempMove);
            controller.Move(tempMove * Time.deltaTime * playerSpeed);
            
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}

