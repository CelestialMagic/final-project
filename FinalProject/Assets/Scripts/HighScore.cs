using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text scoreDisplay;

    private float highScore;

   

    // Start is called before the first frame update
    private void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreDisplay.text = $"{PlayerPrefs.GetFloat("Score")}";
    }

  

    

}


