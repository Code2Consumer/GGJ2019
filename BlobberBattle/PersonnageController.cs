using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	private PersonnageModel model;
	private string horizontalAxis;
	private string verticalAxis;
	private string buttonX;
	private string triggerAxis;
	private GameObject[] bleuWin;
	private GameObject[] redWin;
    private Vector3 initialPositionJ1 = new Vector3(-117, 77,0);
    private Vector3 initialPositionJ2 = new Vector3(27, 77, 0);

    public AudioClip tirNormal;
    public AudioClip degatsNormaux;
    public AudioClip tirSpeciaux;
    public AudioClip degatsSpeciaux;
    public AudioClip Mort;
    private AudioSource source;
    private float volumecourtedistance = .5f;
    private float volumelonguedistance = 1.0f;

	private bool isLooser = false;

    void Awake(){
		model = this.gameObject.GetComponent<PersonnageModel> ();
		bleuWin = GameObject.FindGameObjectsWithTag("bleuwin");
		redWin = GameObject.FindGameObjectsWithTag("rougewin");
		//model.tir = this.gameObject.GetComponent<Tir> ();
	}

	// Use this for initialization

	void Start () {
		model.lastTimePickedUpBonus 	= -20 ;
		model.timeLeftBeforeGetFucked 	= 0f;
		model.timeBeforeGetWell 		= 5.0f;
		model.timeBeforeGetFucked 		= 5.0f;
		model.sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		model.shootPoint = transform.Find ("ShootPoint");
		// model.power = this.gameObject.GetComponent<Power> ();

		model.power = this.gameObject.GetComponent<BonusThrowedScript> ();
		bleuWin[0].SetActive(false);
		redWin [0].SetActive (false);

		horizontalAxis = "J" + model.numeroJoueur + "Horizontal";
		verticalAxis = "J" + model.numeroJoueur + "Vertical";
		buttonX = "J" + model.numeroJoueur + "X";
		triggerAxis = "J" + model.numeroJoueur + "Trigger"; 

		model.anim = this.gameObject.GetComponent<Animator> ();
        //Zak
        //Zak

        model.life = 3;

        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		model.timeLeftBeforeGetFucked 	=  System.Math.Round(model.timeBeforeGetFucked - ( Time.time - model.lastTimePickedUpBonus ), 2);
	
		Debug.Log ("model.isDying"+model.isDying);
		if (!model.isDying) {

			if (model.life == 0) {
				isLooser = true;
				if (model.numeroJoueur == 1) {
					redWin [0].SetActive (true);
				} else {
					bleuWin [0].SetActive (true);

				}
			
			

			}
			if (!isLooser) {
				
				model.deltime = Time.time;
				if ((model.deltime - model.timeSaved) > model.animationTime) {
					model.isShot = false;
				}
				if (model.isShot) {
					model.valRecul = (model.recul * model.percentage) * (int)transform.localScale.x;
					Vector2 temp = new Vector2 (transform.position.x - model.valRecul, transform.position.y); // On fait un vecteur qui le déplace vers la gauche
					transform.position = Vector2.Lerp (transform.position, temp, Time.fixedDeltaTime);

				}


				if (model.isMoving && !model.isAttacking) {
					model.anim.Play ("P" + model.numeroJoueur + "Marche");
				} else if (!model.isAttacking) {
					model.anim.Play ("P" + model.numeroJoueur + "Idle");
				}

				if (Input.GetButton (buttonX)) {
					throwPower ();
				}
				if (Input.GetAxis (triggerAxis) < 0.0) {
					//this.shoot ();
					model.isAttacking = true;
					model.anim.Play ("P" + model.numeroJoueur + "Crachat");
				}


				if (Input.GetAxis (horizontalAxis) != 0.0) {

					if (model.isCollideRight && Input.GetAxis (horizontalAxis) < 0.0) {

						float speed = Input.GetAxis (horizontalAxis) * model.moveSpeed;

						//transform.position = transform.position + inputDirection;
						transform.Translate (speed, 0, 0);

						model.isMoving = true;

					} else if (model.isCollideLeft && Input.GetAxis (horizontalAxis) > 0.0) {

						float speed = Input.GetAxis (horizontalAxis) * model.moveSpeed;

						//transform.position = transform.position + inputDirection;
						transform.Translate (speed, 0, 0);

						model.isMoving = true;

					} else if (!model.isCollideRight && !model.isCollideLeft) {
						float speed = Input.GetAxis (horizontalAxis) * model.moveSpeed;

						//transform.position = transform.position + inputDirection;
						transform.Translate (speed, 0, 0);

						model.isMoving = true;
					}


				} 

				if (Input.GetAxis (verticalAxis) != 0.0) {

					if (model.isCollideTop && Input.GetAxis (verticalAxis) > 0.0) {
				
						float speed = Input.GetAxis (verticalAxis) * model.moveSpeed;
						transform.Translate (0, -speed, 0);

						model.isMoving = true;
					} else if (model.isCollideBottom && Input.GetAxis (verticalAxis) < 0.0) {

						float speed = Input.GetAxis (verticalAxis) * model.moveSpeed;
						transform.Translate (0, -speed, 0);

						model.isMoving = true;
					} else if (!model.isCollideTop && !model.isCollideBottom) {
						float speed = Input.GetAxis (verticalAxis) * model.moveSpeed;
						transform.Translate (0, -speed, 0);

						model.isMoving = true;
					}
				}

				if (Input.GetAxis (verticalAxis) == 0.0 && Input.GetAxis (horizontalAxis) == 0.0) {
					model.isMoving = false;
				}

			}
			else if(isLooser) {
				Debug.Log ("quit");
				if(Input.GetButton("ButtonA")){
					SceneManager.LoadScene("Ui");
				}

			}


		} 
			
	}

	void throwPower(){
    
		if(model.hasBonus){

			AudioSource.PlayClipAtPoint(tirSpeciaux, transform.position);

			model.power.direction = (int) transform.localScale.x;
			Vector3 powerPosition = new Vector3( model.numeroJoueur == 1 ? model.shootPoint.position.x+5 : model.shootPoint.position.x-5  , model.shootPoint.position.y , model.shootPoint.position.z); 
			Instantiate (model.power, powerPosition, model.shootPoint.rotation);
			model.power 	= null;
			model.hasBonus 	= false;

			//applyEffect()
			model.moveSpeed = model.speedBase;
		}

	}

	void shoot(){
		AudioSource.PlayClipAtPoint(tirNormal, transform.position);
		if (model.fireRate == 0) {
			this.instatiateTir ();
		

		} else {
			if(Time.time > model.timeToFire){
				model.timeToFire = Time.time + 1 / model.fireRate;
				this.instatiateTir();
			

			}
		}
	}

	void endShoot(){

		model.isAttacking = false;
	}

	void endDie(){
		Debug.Log ("enddie");

		if (gameObject.name == "Joueur1")
		{
			transform.position = initialPositionJ1;
		}
		if (gameObject.name == "Joueur2")
		{
			transform.position = initialPositionJ2;
		}
		model.life--;
		model.percentage = 0;
		model.hasBonus = false;
		model.hasMalus = false;
		model.isDying = false;
	}
	void instatiateTir(){
		//Debug.Log (model.tir);
		//model.tir.direction = (int) -transform.localScale.x;
		model.tir.directionXY = new Vector3(-gameObject.transform.position.x + (transform.localScale.x /10) , 0, 0);
		Instantiate (model.tir, model.shootPoint.position, model.shootPoint.rotation);
	}

	void flipRight(float translation){
		transform.Translate (new Vector3 (translation, 0, 0));
		Vector3 newScale = transform.localScale;
		newScale.x *= newScale.x;
		transform.localScale = newScale;
	}

	void flipLeft(float translation){
		transform.Translate (new Vector3 (-translation, 0, 0));
		Vector3 newScale = transform.localScale;
		newScale.x *= -newScale.x;
		transform.localScale = newScale;
	}
		

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.tag == "MilieuTerrain")
		{
			if (model.numeroJoueur == 1) {
				model.isCollideRight = false;
			} else if (model.numeroJoueur == 2) {
				model.isCollideLeft = false;
			}

		}

		if (other.gameObject.tag == "MurHaut")
		{
			model.isCollideTop = false;
		}

		if (other.gameObject.tag == "MurBas")
		{
			model.isCollideBottom = false;
		}

	}
	//Zak
	void OnTriggerEnter2D(Collider2D other) {

		if (model.isDying != true ) {
	        if (other.gameObject.tag == "Bonus"){
				if (!model.hasBonus) {
					Debug.Log("Bonus ramaser");
					pickUpBonus();
					model.speedAffection = other.GetComponent<BonusScript> ().speed;
					applyEffect ();
				}
	   
			}

			if (other.gameObject.tag == "Vide")
			{
				Debug.Log ("tombe dans le vide");
				AudioSource.PlayClipAtPoint(Mort, transform.position);
				model.anim.Play ("P" + model.numeroJoueur + "Mort");
				model.isDying = true;
			}
			if (model.isDying != true ) {

				if (other.gameObject.tag == "BonusThrowed") {
					Instantiate (model.impactParticule, transform.position, transform.rotation);
					if (!model.hasMalus) {
						model.hasMalus = true;
						model.speedAffection = other.GetComponent<BonusThrowedScript> ().speedAffection;
						applyEffect ();
						Destroy (other.gameObject);
					}
					

				}
			}


	        if (other.gameObject.tag == "MilieuTerrain")
	        {
				if (model.numeroJoueur == 1) {
					model.isCollideRight = true;
				} else if (model.numeroJoueur == 2) {
					model.isCollideLeft = true;
				}

	        }

	        if (other.gameObject.tag == "MurHaut")
	        {
				model.isCollideTop = true;  
	        }

	        if (other.gameObject.tag == "MurBas")
	        {
				model.isCollideBottom = true;  
	        }



			Tir shot = other.gameObject.GetComponent<Tir> ();
			if (shot != null) { // Si l'objet qui le touche contient le scrip BulletBehavior
				
				model.percentage+=shot.bulletDamage; // On augmente les pourcentages du nombre de dégat de la balle
				model.isShot = true; // On déclare que le joueur se fait toucher.
				model.timeSaved = Time.time;

				model.anim.Play ("P" + model.numeroJoueur + "PrendreUnCoup");
			}
		}
	}

	void tombeDansLeVide(){
		Destroy(gameObject);
	}

	void pickUpBonus(){
		model.lastTimePickedUpBonus 	= Time.time;
		model.hasBonus 					= true;
	}

	IEnumerator LoadChangeBonusToMalus(float temps){
		yield return new WaitForSeconds (temps);
		if (model.hasBonus) {
			youAreFucked ();
		}


	}

	IEnumerator LoadEndMalus(float temps){
		yield return new WaitForSeconds (temps);
		model.hasMalus = false;
		applyEffect ();

	}

	void applyEffect(){
		if (model.hasBonus) {
			model.moveSpeed += model.speedAffection;
			StartCoroutine (LoadChangeBonusToMalus (model.timeBeforeGetFucked));

			Debug.Log ("Bonus");
		} 

		if(model.hasMalus){
			model.moveSpeed -= model.speedAffection;
			StartCoroutine (LoadEndMalus (model.timeBeforeGetWell));
	
			Debug.Log ("Malus");
		}

		if (!model.hasMalus && !model.hasBonus) {
			model.moveSpeed = model.speedBase;
			Debug.Log ("Fin de malus");
		
		}


	}

	void youAreFucked(){
		model.hasBonus = false;
		model.hasMalus = true;
		model.speedAffection *= 2;
		model.power = null;
		applyEffect ();
	}
		


	public PersonnageModel getModel(){
		return this.model;
	}
	//Zak
	
}
