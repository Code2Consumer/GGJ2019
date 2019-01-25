using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public  GameObject  enemyObject;
    private Vector3[] linePositions = {
            new Vector3(6, 4, 0),
            new Vector3(6, 1, 0),
            new Vector3(6, -2, 0)
        };
    private float nextSpawnTime = 0.0f;
    private float period = 1.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime ) {
            nextSpawnTime = Time.time+period;
            Debug.Log(period);
            spawnEnemy();
        }
    }

    void spawnEnemy(){
        Instantiate (enemyObject, this.getRandomSpawnLine() ,  Quaternion.identity );
    }

    private Vector3 getRandomSpawnLine(){
        //int spawnValue = Random.Range(0, 3);
        int spawnValue = RandomNumber(0, 3);
        Debug.Log(spawnValue);
        return linePositions[spawnValue];
    }

    public int RandomNumber(int min, int max)  
    {  
        System.Random random = new System.Random();
        return random.Next(min, max);  
    }
}
