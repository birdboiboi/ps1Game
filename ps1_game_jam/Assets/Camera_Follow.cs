using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    public Transform origin;

    // Update is called once per frame
    void Update()
    {
        Vector3 normalDir = player.transform.position - origin.transform.position;
        transform.position = player.transform.position + Vector3.Normalize(normalDir)*4;
        transform.LookAt(origin.transform.position);
       
    }
}
