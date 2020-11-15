using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour
{
    //public Texture labelTexture;
    public int letterCount = 0;
    //public Collectable hearts;

    private GUIStyle guiStyle = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("close");
        }
    }
    
    void OnGUI()
    {
        guiStyle.fontSize = 20;
        //guiStyle.Color = Color.white;
        GUI.Label(new Rect(10, 10, 300, 20), "Lost Love Letters Found <3: "+ letterCount, guiStyle);
    }
}
