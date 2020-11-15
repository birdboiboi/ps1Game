using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject mainCamera;
    public SpriteRenderer player2d;
    public GameObject player3d;
    public float cam2dOffset;
    private Vector3 contraint;
    private bool inWall = false;
    // Start is called before the first frame update
    void Start()
    {
        player2d.enabled = false;
        contraint = new Vector3(1,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")   &&  inWall )
        {
            player2d.enabled = false;
            player3d.SetActive(true);
            player3d.transform.position = player2d.transform.position + Vector3.up *3 ;
            player3d.transform.rotation = player2d.transform.rotation;
            //player3d.transform.Rotate(0, 90, 0);
            
            inWall = false;
            mainCamera.GetComponent<Camera_Follow>().enabled = true;
            mainCamera.transform.parent = null;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("enter");
        if (col.tag == player3d.tag)
        {
            
            col.gameObject.SetActive(false);

            player2d.transform.position = player3d.transform.position + player3d.transform.up * 2;
            player2d.transform.eulerAngles = transform.eulerAngles + new Vector3(90,0,0);
            player2d.enabled = true;
            mainCamera.transform.position = player2d.transform.position + player2d.transform.forward * cam2dOffset ;
            mainCamera.GetComponent<Camera_Follow>().enabled = false;
            mainCamera.transform.LookAt(player2d.transform);
            mainCamera.transform.parent = player2d.transform;
            inWall = true;
        }
    }
}
