using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> obstaclePrefabs; //a list of the obstacles
    [SerializeField]
    protected float spawnMinTime; //The minimum amount of time to wait before spawning an obstacle
    [SerializeField]
    protected float spawnMaxTime; //The maximum amount of time to wait before spawning an obstacle
    [SerializeField]
    protected float startSpawnTime; //When the obstacles start spawning (so we can give the player a bit of time before it starts)
    [SerializeField]
    protected float spawnXlocation;
    [SerializeField]
    protected float spawnYlocation;

    protected float nextSpawnTime; //the next time so spawn an obstacle

    protected void Start()
    {
        //Initalize when you will spawn the first obstacle here
        nextSpawnTime = Time.time + startSpawnTime + Random.Range(spawnMinTime, spawnMaxTime); //Time.time is current time ellapsed in seconds from when the game starts;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Here we will want to check if it's time to spawn another obstacle. 
        if (nextSpawnTime < Time.time && GameStateManager.CanSpawn == true) //if the nextSpawnTime is NOW or in the past, spawn an obstacle
        {
            //Randomly select an obstacle 
                int random = Random.Range(0, obstaclePrefabs.Count); //Choose a random type of obstacle from the list
                //Use Instantiate to create an instance of that template in the game world.
                GameObject go = Instantiate(obstaclePrefabs[random]);
                go.transform.Translate(spawnXlocation, spawnYlocation, 0f);
                //Select the next time to spawn an obstactle
                nextSpawnTime += Random.Range(spawnMinTime, spawnMaxTime); //update the nextSpawnTime so we can spawn more!
        }
    }
}