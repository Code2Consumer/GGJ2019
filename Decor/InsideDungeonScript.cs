using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDungeonScript : MonoBehaviour
{
	public int lifePoint = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(lifePoint);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeLifePoints(int points){
    	lifePoint = lifePoint - points;
        // Debug.Log(lifePoint);
        if(lifePoint <= 0){
        	gameOver();
        	Destroy(gameObject);
        }
    }

    void gameOver(){
    	GameObject.Find("Canvas").GetComponent<HUDScript>().gameOver();
    }

}
