using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    public Transform origin;
    public float transitionSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 normalDir = player.transform.position - origin.transform.position;
        Vector3 newPos = player.transform.position + Vector3.Normalize(normalDir) * 4;
        float dist_targ_pos = Vector3.Magnitude(transform.position - newPos);
        transform.position = Vector3.Lerp(transform.position, newPos , Time.deltaTime * transitionSpeed * dist_targ_pos);

        transform.LookAt(origin.transform.position);
       
    }
}
