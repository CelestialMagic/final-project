using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;//Represents the move speed of the background image
    [SerializeField]
    private float reset;//Represents the point where the background image will reset

    private Vector3 startPos;//Represents the starting location of the image

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //The image moves gradually 
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        //If the image x position is less than the reset, the image returns to
        //where it started and loops again. 
        if (transform.position.x < reset)
        {
            transform.position = startPos;
        }

    }
}
