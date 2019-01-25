using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	public float walkSpeed;

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
        if (other.gameObject.name == "insideDungeonTrigger" || other.gameObject.name == "insideDungeonTrigger(Clone)" ) {
            //Debug.Log("Out of Map ");
            Destroy(gameObject);
        }
    }
}
