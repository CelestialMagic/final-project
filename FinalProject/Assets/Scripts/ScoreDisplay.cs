using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    //The GameObject displaying the score
    [SerializeField]
    protected Text scoreDisplay;

   

    [SerializeField]
    private PlayerController pc;


    // Start is called before the first frame update
    protected virtual void Start()
    {

        DisplayScore();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        DisplayScore();
    }

    protected virtual void DisplayScore()
    {
        scoreDisplay.text = $"Distance: {pc.GetScore()}";
    }
}
