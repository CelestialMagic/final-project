using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacles : Obstacles
{
    [SerializeField] //for the flying behavior, we want the obstacles to move up and down
    private float maxHeight;
    [SerializeField]
    private float minHeight;
    [SerializeField] //if this doesn't work delete later
    private float verticalSpeed;


    // Update is called once per frame
    protected override void Update()
    {
        //floating behavior:
        if (transform.position.y > maxHeight) //If the flying obstacle is at the top of its height, start moving down
        {
            transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, -verticalSpeed * Time.deltaTime, 0f);
        } else if (transform.position.y < minHeight)
        {
            transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0f);
        }

    }
}
