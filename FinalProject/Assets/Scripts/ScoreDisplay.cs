using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{
    //The GameObject displaying the score
    [SerializeField]
    protected Text scoreDisplay;

    //The GameObject that is scoring the points (player)
    [SerializeField]
    protected GameObject scorer;

    [SerializeField]
    private PlayerController pc; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Retrieves score from scorer object with PlayerController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {pc.GetScore() / 1000}";
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Updates score with PlayerController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {pc.GetScore() / 1000}";
    }
}
