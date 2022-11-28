using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingObstacleSpawner : ObstacleSpawner
{
    [SerializeField]
    private List<float> spawnLocations;


    protected virtual void Update()
    {
        if (nextSpawnTime < Time.time && GameStateManager.CanSpawn == true) //if the nextSpawnTime is NOW or in the past, spawn an obstacle
        {
                int randomObstacle = Random.Range(0, obstaclePrefabs.Count); //Choose a random type of obstacle from the list
                int randomLocation = Random.Range(0, spawnLocations.Count); //Choose a random spawn location from the list
                //Use Instantiate to create an instance of that template in the game world.
                GameObject go = Instantiate(obstaclePrefabs[randomObstacle]);
                go.transform.Translate(randomLocation, spawnYlocation, 0f);
                //Select the next time to spawn an obstactle
                nextSpawnTime += Random.Range(spawnMinTime, spawnMaxTime); //update the nextSpawnTime so we can spawn more!
        }
    }
}
