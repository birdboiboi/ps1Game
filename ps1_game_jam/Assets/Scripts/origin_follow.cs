using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin_follow : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.Scale(target.position ,Vector3.up);
        transform.LookAt(target);
    }
}
