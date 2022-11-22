using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    protected Text scoreDisplay;

    private float highScore;

    // Start is called before the first frame update
    protected void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    protected void Update()
    {
        DisplayScore();
    }

    //DisplayScore() method overridden by inherited classes
    protected virtual void DisplayScore()
    {
        scoreDisplay.text = $"{PlayerPrefs.GetFloat("Score")}";
    }

  

    

}


