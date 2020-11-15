using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    public Transform origin;
    public float transitionSpeed;
    public bool camDir = false;
    public float offsetDist = 4;
    private CharacterCobntroller cntrl;
    private float tempSpeed;

    void Start()
    {
        cntrl = player.GetComponent<CharacterCobntroller>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            camDir = !camDir;
        }
        Vector3 normalDir = player.transform.position - origin.transform.position;
        if (camDir)
        {
            cntrl.invertCntrls = -1;
            cntrl.invertCntrls = tempSpeed;
            Vector3 newPos = player.transform.position + Vector3.Normalize(normalDir) * offsetDist;
            float dist_targ_pos = Vector3.Magnitude(transform.position - newPos);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed * dist_targ_pos);
            transform.LookAt(origin.transform.position);
        }
        else
        {
            cntrl.invertCntrls = 1;
            cntrl.invertCntrls = tempSpeed * 100;
            Vector3 newPos = origin.transform.position;
            float dist_targ_pos = Vector3.Magnitude(transform.position - newPos);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed * dist_targ_pos);
            transform.LookAt(player.transform.position);

        }
       
    }

    
}
