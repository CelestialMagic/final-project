using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : BackgroundMover
{
    // Update is called once per frame
    protected override void Update()
    {
        //The image moves gradually 
        transform.position += new Vector3(0f, -moveSpeed * Time.deltaTime, 0f);
        //If the image y position is less than the reset, the image returns to
        //where it started and loops again. 
        if (transform.position.y < reset)
        {
            transform.position = startPos;
        }
    }
}
