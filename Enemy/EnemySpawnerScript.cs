using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    private Vector3[] linePositions = {
            new Vector3(24, 9, 0),
            new Vector3(24, 2, 0),
            new Vector3(24, -4, 0)
        };
    public  GameObject  enemyObject;
    private float nextSpawnTime = 0.0f;
    private float period = 3f;
    private float distanceEntreDifferentEnemyQuiSpawnEnMemeTemp = 1;
    private float timeSinceNewSession = 0;

    private System.Random random = new System.Random();
    
    // Start is called before the first frame update
    void Start()
    {
        timeSinceNewSession = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime ) {
            nextSpawnTime = Time.time+period;
            // Debug.Log(period);
            spawnEnemy();
        }
    }

    void spawnEnemy(){
        int amountOfEnemyToSpawn    = random.Next(1,4)+ ( (int) (Time.time-timeSinceNewSession) /10 );
        int randomSpawnPicker       = random.Next(0,3);
        Vector3 spawnPosition       = linePositions[randomSpawnPicker];
        
        //Debug.Log(amountOfEnemyToSpawn);
        //Debug.Log(randomSpawnPicker);

        // int amountOfEnemyToSpawn = RandomNumber(1,4) + ( (int) Time.time/10 );
        // Debug.Log(Time.time);

        // int distanceADistribuer = distanceEntreDifferentEnemyQuiSpawnEnMemeTemp * amountOfEnemyToSpawn - distanceEntreDifferentEnemyQuiSpawnEnMemeTemp;
        for (int i = 0; i < amountOfEnemyToSpawn; i++)
        {
            Instantiate (
                enemyObject, 
                new Vector3(
                    spawnPosition[0] + distanceEntreDifferentEnemyQuiSpawnEnMemeTemp * i, 
                    spawnPosition[1], 
                    spawnPosition[2]
                    ),  
                Quaternion.identity 
                );
        }
    }

/*    private Vector3 getRandomSpawnLine(){
        int spawnValue = RandomNumber(0, 3);
//        Debug.Log(spawnValue);
        return linePositions[spawnValue];
    }

    public int RandomNumber(int min, int max)  
    {  
        System.Random random = new System.Random();
        return random.Next(min, max);  
    }*/
}
