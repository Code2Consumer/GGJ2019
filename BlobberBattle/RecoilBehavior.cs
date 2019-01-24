using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilBehavior : MonoBehaviour {
	
	public float pourcentage = 1;
	public float recul= 0.5f;
	private bool isShot = false;
	private float valRecul = 0.1f;
	private float timeSaved;
	private float deltime;
	public float animationTime = 0.5f;

	// Update is called once per frame
	void Update () {

		deltime = Time.time;
		if ((deltime - timeSaved) > animationTime){
			isShot = false;
		}
		if (isShot) {
			valRecul = recul*pourcentage;
			Vector2 temp = new Vector2 (transform.position.x-valRecul,transform.position.y); // On fait un vecteur qui le déplace vers la gauche
			transform.position = Vector2.Lerp (transform.position, temp,Time.fixedDeltaTime);

		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Tir shot = collider.gameObject.GetComponent<Tir> ();
		if (shot != null) { // Si l'objet qui le touche contient le scrip BulletBehavior
			pourcentage+=shot.bulletDamage; // On augmente les pourcentages du nombre de dégat de la balle
			isShot = true; // On déclare que le joueur se fait toucher.
			timeSaved = Time.time;
		}
	}
}
