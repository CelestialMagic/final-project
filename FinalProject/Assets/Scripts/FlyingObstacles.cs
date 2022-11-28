using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacles : Obstacles
{
    [SerializeField] //float representing max height of a floating obstacle
    private float maxHeight;
    [SerializeField]
    private float minHeight;//float representing min height of a floating obstacle

    private bool isRising;//bool used to determine if an obstacle is floating

    private int flip;//int used to determine negative or positive movement



    // Update is called once per frame
    protected override void Update()
    {
        
        //floating behavior:
        if (transform.position.y >= maxHeight)
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

    //FlipMovement() determines when to move an obstacle up or down. 
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
