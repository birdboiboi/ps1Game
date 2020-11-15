using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{
    private SpriteRenderer rend;
    public string cmd;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
  
   
    void OnMouseExit()
    {
        
        rend.color = Color.white;
    }
    void OnMouseDown()
    {
        rend.color = Color.blue;
        Debug.Log("howdy");
        ExecScrpt(cmd);
    }
    void OnMouseUp()
    { 
        OnMouseExit();
    }
    void ExecScrpt(string cmd)
    {
        switch (cmd)
        {
            case "OpenScene":
                OpenScene();
                break;
            case "EndGame":
                EndGame();
                break;
        }
    }

    public void OpenScene()
    {
        //SceneManager.LoadScene("play_test");
        SceneManager.LoadScene("play_test");
    }
    public void EndGame()
    {
        Application.Quit();
    }

}



