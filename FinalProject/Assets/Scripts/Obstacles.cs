using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
   
    // Update is called once per frame
    protected virtual void Update()
    {
        //Move the obstacle a little bit each frame
        transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, 0f, 0f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {

        //This method is called when the object enters a collider trigger. 
        //We don't want an infinite number of obstacles in the game world 
        //Here we should see if the obstacle has entered the "Despawn" trigger
        //so that we can destroy the object.

        if (collision.tag == "Despawn")
        {
            Destroy(gameObject);
        }
        
    }
}
