using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHover : MonoBehaviour
{
    public float radius = 10;
    public float speed = 1;
    public float rotateSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, radius * Mathf.Cos(Time.time + speed), 0));
        transform.Rotate(0, rotateSpeed, 0);
    }
}
