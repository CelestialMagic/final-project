using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //We will maybe set up obstacle movespeed in the GameStateManager class, but for now heres this:
   
    // Update is called once per frame
    void Update()
    {
        //Move the obstacle a little bit each frame
        transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This method is called when the object enters a collider trigger. 
        //We don't want an infinite number of obstacles in the game world 
        //Here we should see if the obstacle has entered the "Despawn" trigger so that we can destroy the object.

        if (collision.tag == "Despawn") //this collision tag is just a string
        {
            Destroy(gameObject); //Destroy the obstacle!
        }
        
    }
}
