using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAction(){
    	Application.LoadLevel("Level1Master");
    }

    public void exitAction(){
    	Application.Quit();
    }
}
