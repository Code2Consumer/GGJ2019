﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

	private GameObject GameOverText;
	private GameObject ScoreText;
	private GameObject RageBarUI;
	private GameObject RageBarLevelUI;

	private float rageBarOriginalWidth 	= 0;
	private float rageBarOriginalHeight = 0;
	public float val = 0;
    // Start is called before the first frame update
    void Start()
    {
    	RageBarUI 		= GameObject.Find("RageBarUI");
    	RageBarLevelUI 	= GameObject.Find("RageBarLevelUI");
		GameOverText 	= GameObject.Find("GameOverText");
    	ScoreText 		= GameObject.Find("ScoreText");

    	rageBarOriginalWidth 	=  RageBarUI.GetComponent<RectTransform>().sizeDelta.x;
    	rageBarOriginalHeight 	=  RageBarUI.GetComponent<RectTransform>().sizeDelta.y;
    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = false;
        // updateRageBar(val);
    }

    // Update is called once per frame
    void Update()
    {
    	Debug.Log(val);
    }

    public void gameOver(){
    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = true;
    }

    public void updateLifePoints(int lifePoint){
    	Destroy(GameObject.Find("heart"+(lifePoint+1)+"UI"));
    }

    public void updateScore(int score){
    	ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score:"+score;
    }

  //   public void updateRageBar(float ragePercentage){
  //   	ragePercentage  		= ragePercentage > 1 ? 1 : ragePercentage;
  //   	float rageBarWidth 		= rageBarOriginalWidth * ragePercentage;
  //   	float rageBarPosition 	= rageBarOriginalWidth - rageBarWidth;
  //   	rageBarPosition = rageBarPosition-(rageBarWidth/2);
  //   	rageBarPosition = rageBarPosition < -250 ? -250 : rageBarPosition;
  //   	Debug.Log("rageBarPosition:" + rageBarPosition);
  //   	Debug.Log("rageBarWidth:" + rageBarWidth);
  //   	Debug.Log("rageBarPosition-(rageBarWidth/2):" + (rageBarPosition-(rageBarWidth/2)));
		// // RageBarUI.GetComponent<RectTransform>().sizeDelta.x = rageBarWidth;
		// RageBarLevelUI.GetComponent<RectTransform>().position 	= new Vector2(rageBarPosition, RageBarLevelUI.GetComponent<RectTransform>().position.y);
		// RageBarLevelUI.GetComponent<RectTransform>().sizeDelta 	= new Vector2(rageBarWidth, rageBarOriginalHeight);
  //   }
}
