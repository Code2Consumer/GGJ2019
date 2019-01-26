using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

	private GameObject GameOverText;
	private GameObject RetryTextButton;
	private GameObject ScoreText;
	private GameObject RageBarScrollBarUI;

	private float rageBarOriginalWidth 	= 0;
	private float rageBarOriginalHeight = 0;
	private int scoreTotal 			= 0;
	
	// public float val = 0;

    // Start is called before the first frame update
    void Start()
    {
		GameOverText 			= GameObject.Find("GameOverText");
		RetryTextButton 		= GameObject.Find("RetryTextButton");
    	ScoreText 				= GameObject.Find("ScoreText");
    	RageBarScrollBarUI		= GameObject.Find("RageBarScrollBarUI");

    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = false;
    	RetryTextButton.GetComponent<UnityEngine.UI.Text>().enabled = false;

    	updateRageBar(0);
    }

    // Update is called once per frame
    void Update()
    {
    	// updateRageBar(0.3f);
    }

    public void updateLifePoints(int lifePoint){
    	Destroy(GameObject.Find("heart"+(lifePoint+1)+"UI"));
    }

    public void addPointsToScore(int points){
    	scoreTotal = scoreTotal + points;
    	updateScore(scoreTotal);
    }

    public void updateScore(int score){
    	ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score:"+score;
    }

    public void gameOver(){
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playGameOver();

    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = true;
    	RetryTextButton.GetComponent<UnityEngine.UI.Text>().enabled = true;
    }

    public void retryAction(){
    	Application.LoadLevel(Application.loadedLevel);
    }

    public void updateRageBar(float ragePercentage){
    	ragePercentage  		= ragePercentage > 1 ? 1 : ragePercentage;
		RageBarScrollBarUI.GetComponent<UnityEngine.UI.Scrollbar>().size = ragePercentage;
	}
}
