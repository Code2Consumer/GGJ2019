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
    	// transform.position.x = transform.position.x * 
    	// ( walkSpeed * -1 );
        transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);
    } 
}
