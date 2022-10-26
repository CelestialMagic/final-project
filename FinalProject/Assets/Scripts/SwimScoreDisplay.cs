using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimScoreDisplay : ScoreDisplay
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //Retrieves starting score from scorer object with SwimmingController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {scorer.GetComponent<SwimmingController>().GetScore() / 1000}";
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Updates score with SwimmingController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {scorer.GetComponent<SwimmingController>().GetScore() / 1000}";
    }
}
