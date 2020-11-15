using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    public Transform cam;
    private CharacterController controller;
 
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        
 
        transform.LookAt(cam);
        Vector3 normalDir = cam.position - transform.position;
        Vector3 move = new Vector3(0, Input.GetAxis("Horizontal"),0);
        move = Vector3.Cross(normalDir, move).normalized;
        controller.Move(move * Time.deltaTime );

    }
}
