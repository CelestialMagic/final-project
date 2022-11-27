using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimObstacles : Obstacles
{
    // Update is called once per frame
    protected override void Update()
    {
        transform.Translate(0f, -GameStateManager.ObstacleMoveSpeed * Time.deltaTime, 0f);
    }
}
