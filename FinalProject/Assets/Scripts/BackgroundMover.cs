using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    private float reset;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x < reset)
        {
            transform.position = startPos;
        }
    }
}
