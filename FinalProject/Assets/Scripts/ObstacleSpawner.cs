using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstaclePrefabs; //a list of the obstacles
    [SerializeField]
    private float spawnMinTime; //The minimum amount of time to wait before spawning an obstacle
    [SerializeField]
    private float spawnMaxTime; //The maximum amount of time to wait before spawning an obstacle
    [SerializeField]
    private float startSpawnTime; //When the obstacles start spawning (so we can give the player a bit of time before it starts)
    [SerializeField]
    private float spawnXlocation;
    [SerializeField]
    private float spawnYlocation;

    private float nextSpawnTime; //the next time so spawn an obstacle

    void Start()
    {
        //Initalize when you will spawn the first pillar here.
        nextSpawnTime = Time.time + startSpawnTime + Random.Range(spawnMinTime, spawnMaxTime); //Time.time is current time ellapsed in seconds from when the game starts;
    }

    // Update is called once per frame
    void Update()
    {
        //Here we will want to check if it's time to spawn another obstacle. 
        if (nextSpawnTime < Time.time && GameStateManager.CanSpawn == true) //if the nextSpawnTime is NOW or in the past, spawn an obstacle
        {
            //Randomly select an obstacle 
                int random = Random.Range(0, obstaclePrefabs.Count); //Choose a random type of pillar from the list
                //Use Instantiate to create an instance of that template in the game world.
                GameObject go = Instantiate(obstaclePrefabs[random]);
                go.transform.Translate(spawnXlocation, spawnYlocation, 0f);
                //Select the next time to spawn an obstactle
                nextSpawnTime += Random.Range(spawnMinTime, spawnMaxTime); //update the nextSpawnTime so we can spawn more!
        }
    }
}