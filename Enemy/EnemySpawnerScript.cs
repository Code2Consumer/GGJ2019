using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    private Vector3[] linePositions = {
            new Vector3(6, 4, 0),
            new Vector3(6, 1, 0),
            new Vector3(6, -2, 0)
        };
    public  GameObject  enemyObject;
    private float nextSpawnTime = 0.0f;
    private float period = 3f;
    private float distanceEntreDifferentEnemyQuiSpawnEnMemeTemp = 1;

    // Start is called before the first frame update
    void Start()
    {

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
        Vector3 spawnPosition = this.getRandomSpawnLine();
        int amountOfEnemyToSpawn = RandomNumber(1,4);
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

    private Vector3 getRandomSpawnLine(){
        int spawnValue = RandomNumber(0, 3);
//        Debug.Log(spawnValue);
        return linePositions[spawnValue];
    }

    public int RandomNumber(int min, int max)  
    {  
        System.Random random = new System.Random();
        return random.Next(min, max);  
    }
}
