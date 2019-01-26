using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	public float walkSpeed = 5;
    public int damage = 1;

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
        transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "insideDungeon" || other.gameObject.name == "insideDungeon(Clone)" ) {
            other.gameObject.GetComponent<InsideDungeonScript>().removeLifePoints(damage);
            Destroy(gameObject);
        }else if (other.gameObject.tag == "Attaque") {
            GameObject.Find("Canvas").GetComponent<HUDScript>().addPointsToScore(10);
            die();
        }
    }

    void die(){
        Destroy(gameObject);
    }
}
