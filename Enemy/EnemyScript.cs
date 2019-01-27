using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	public float walkSpeed = 5;
    public int damage = 1;
    public GameObject objectAnnimation;

    private bool isDead = false ;
    private float deathTime = 0;
    private float annimationDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        walkLeft();
    }

    void walkLeft(){
        if(!isDead){
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(!isDead){
            if (other.gameObject.name == "insideDungeon" || other.gameObject.name == "insideDungeon(Clone)" ) {
                other.gameObject.GetComponent<InsideDungeonScript>().removeLifePoints(damage);
                Destroy(gameObject);
            }else if (other.gameObject.tag == "Attaque") {
                GameObject.Find("Chevalier").GetComponent<Chevalier_Deplacement>().addPointsToScore();
                GameObject.Find("Canvas").GetComponent<HUDScript>().updateScore();
                die();
            }
        }else{
            if(Time.time - deathTime > annimationDuration){
                Destroy(gameObject);
            }
        }
    }

    void die(){
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playKill();
        objectAnnimation.GetComponent<Animator>().SetTrigger("IsDead");
        gameObject.GetComponent<Collider2D>().enabled = false ;
        isDead = true;
        deathTime = Time.time;
    }
}
