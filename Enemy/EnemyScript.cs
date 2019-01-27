using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	public float walkSpeed = 5;
    public int damage = 1;
    public GameObject objectAnnimation;



    public GameObject gerrier;
    public GameObject tank;
    public GameObject sorciere;
    public GameObject canar;
    private System.Random random = new System.Random();

    private GameObject  currentEnemy;
    private string      curentSound;



    private bool isDead = false ;
    private float deathTime = 0;
    private float annimationDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyTypes = {
                gerrier,
                tank,
                sorciere,
                canar,
        };
        string[] enemySounds =
        {
            "Kill",
            "Kill",
            "Kill_Girl",
            "Kill_Duck"
        };
        int randomEnemyValue = random.Next(0, 3);
        currentEnemy = enemyTypes[randomEnemyValue];
        int randomEnemySoundValue = random.Next(0, 3);
        curentSound = enemySounds[randomEnemySoundValue];
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
