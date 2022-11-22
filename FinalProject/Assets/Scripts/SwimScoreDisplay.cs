using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimScoreDisplay : HighScore
{
    [SerializeField]
    private SwimmingController sc;

    protected override void DisplayScore()
    {
        scoreDisplay.text = $"Distance: {sc.GetScore()}";
    }
}
