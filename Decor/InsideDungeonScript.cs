using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDungeonScript : MonoBehaviour
{
	public int lifePoint = 5;

    // Start is called before the first frame update
    void Start()
    {
    	GameObject.Find("Canvas").GetComponent<HUDScript>().updateLifePoints(lifePoint);
        //Debug.Log(lifePoint);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeLifePoints(int points){
    	if(lifePoint > 0){
	    	lifePoint = lifePoint - points;
	    	GameObject.Find("Canvas").GetComponent<HUDScript>().updateLifePoints(lifePoint);
  	  		GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playHealthLoss();
    	}
        if(lifePoint <= 0){
        	gameOver();
        }
    }

    void gameOver(){
    	GameObject.Find("Canvas").GetComponent<HUDScript>().gameOver();
    }

}
