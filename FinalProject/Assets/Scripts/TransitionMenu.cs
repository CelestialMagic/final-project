using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMenu : StartMenu
{
    // Start is called before the first frame update
    protected override void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(GameStateManager.GetGameState() == "GAMEOVER")
        {
            gameObject.SetActive(true);
        }
    }
}
