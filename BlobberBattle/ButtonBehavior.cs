using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	private GameObject[] pauseObjects;
	private bool isActive;

	void Awake() {
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
	}
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		hidePaused();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Pause")) {
			
			if (isActive) {
				Time.timeScale = 0;
				Debug.Log("Temps pausé");
				showPaused();


			} else if (!isActive) {
				Time.timeScale = 1;
				Debug.Log("Temps repris");
				hidePaused();
			}
		}

	
	}

	public void reprendre(){
			Time.timeScale = 1;
			hidePaused();
	}

	public void showPaused(){
		foreach (GameObject g in pauseObjects) {
			
			g.SetActive(true);
			isActive = !isActive;
			Debug.Log (isActive);
		}
	}

	public void hidePaused(){
		foreach (GameObject g in pauseObjects) {
			g.SetActive(false);
			isActive = !isActive;
			Debug.Log (isActive);
		}
	}
				
	public void LoadLevel(string index){
		SceneManager.LoadScene(index);
	}

	public void QuitButton(){
		Debug.Log("Quit");
		Application.Quit();
	}
}