using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //public bool isGrabbed = 0;
    public GameObject player3d;
    public GameObject player2d;
    public Game_Master gm;
    // Start is called before the first frame update
 

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag == player3d.tag || col.tag == player2d.tag)
        {
            gm.letterCount++;
            this.gameObject.SetActive(false);
        }
    }
}
