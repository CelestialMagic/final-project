using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimScoreDisplay : ScoreDisplay
{
    [SerializeField]
    private SwimmingController sc;

    
   
    // Start is called before the first frame update
    protected override void Start()
    {
        //Retrieves starting score from scorer object with SwimmingController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {sc.GetScore() / divider}";
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Updates score with SwimmingController.GetScore()
        //Converted to kilometers
        scoreDisplay.text = $"Distance: {sc.GetScore() / divider}";
    }
}
