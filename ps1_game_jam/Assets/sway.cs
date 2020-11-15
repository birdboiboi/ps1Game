using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{
    public float swaySpeed = .00001f;
    public float swayRadius = .00000000001f;
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(swayRadius * Mathf.Sin(Time.time), swayRadius* Mathf.Cos(Time.time)));
    }
}
