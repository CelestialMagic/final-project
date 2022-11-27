using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacles : Obstacles
{
    [SerializeField] //for the flying behavior, we want the obstacles to move up and down
    private float maxHeight;
    [SerializeField]
    private float minHeight;

    private bool isRising;

    private int flip; 



    // Update is called once per frame
    protected override void Update()
    {
        
        //floating behavior:
        if (transform.position.y >= maxHeight) //If the flying obstacle is at the top of its height, start moving down
        {
            isRising = false;
            FlipMovement();
            transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, flip * GameStateManager.VerticalMoveSpeed * Time.deltaTime, 0f);
         
        }
        else if(transform.position.y <= minHeight)
        {
            isRising = true;
            FlipMovement();
            transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, flip * GameStateManager.VerticalMoveSpeed * Time.deltaTime, 0f);

        }
        else
        {
            transform.Translate(-GameStateManager.ObstacleMoveSpeed * Time.deltaTime, flip * GameStateManager.VerticalMoveSpeed * Time.deltaTime, 0f);

        }



        }
    private void FlipMovement()
    {
        if(isRising == true)
        {
            flip = 1;
        }
        else 
        {
            flip = -1; 
        }
    }
    }
