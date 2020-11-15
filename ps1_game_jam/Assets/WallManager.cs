using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject mainCamera;
    public SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("enter");
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            player.enabled = true;
        }
    }
}
