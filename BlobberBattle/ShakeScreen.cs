using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour {

	public float ShakeAmount = 0;
	public float ShakeDuration = 0;

	void Awake()
	{

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Shake(){
		InvokeRepeating ("BeginShake", 0, ShakeDuration);
		Invoke ("StopShake", ShakeDuration);
	}

	void BeginShake()
	{
		if (ShakeAmount > 0) {

			Vector3 camPos = Camera.main.transform.position;
			float ShakeAmountX = Random.value * ShakeAmount * 2 - ShakeAmount;
			float ShakeAmountY = Random.value * ShakeAmount * 2 - ShakeAmount;

			camPos.x += ShakeAmountX;
			camPos.y += ShakeAmountY;

			Camera.main.transform.position = camPos;
		}

	}

	void StopShake(){
		CancelInvoke ("BeginShake");
		Camera.main.transform.localPosition = new Vector3 (0, 0, -10);
	}

}
