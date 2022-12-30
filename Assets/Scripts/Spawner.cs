using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float spawnTime;
    public float startSpawnTime;
    public float minSpawnTime;
    public float decreaseSpawnTime;

    public GameObject player;
    public Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (spawnTime <= 0)
            {
                //selecting random spawnpoint and random hazard
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                //spawning the hazard at the spawnpoint
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                //progressively decrease the time between enemy spawn to increase difficulty
                if (startSpawnTime > minSpawnTime)
                {
                    startSpawnTime -= (decreaseSpawnTime * playerScript.difficultyScale);
                }

                //reset spawn time
                spawnTime = startSpawnTime;
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
        
    }

}
