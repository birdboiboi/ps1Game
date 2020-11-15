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
        Debug.Log(move);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") )
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log("jump");
           
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}

