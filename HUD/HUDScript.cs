using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver(){
    	GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>().enabled = true;
    }
}
