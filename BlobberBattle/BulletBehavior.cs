using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	public Vector2 Vec = new Vector2 ();
	public float bulletDamage;
	// Use this for initialization
	void Start () {
		Vec.Set (-0.5f,0);
		Destroy (gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vec);
	}
		
	void OnTriggerEnter2D(Collider2D collider){
		Destroy (gameObject);
	}


}
