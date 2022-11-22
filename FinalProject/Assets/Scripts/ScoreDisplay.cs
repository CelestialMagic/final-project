using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : HighScore
{
    [SerializeField]
    private PlayerController pc;

    protected override void DisplayScore()
    {
        scoreDisplay.text = $"Distance: {pc.GetScore()}";
    }
}
