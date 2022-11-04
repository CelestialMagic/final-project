using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMenu : StartMenu
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //Hides the menu
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        //This is intended to retrieve the game state and display the menu.
        string gameState = GameStateManager.GetGameState();
        Debug.Log(GameStateManager.GetGameState());
        if (gameState == "GAMEOVER")
        {
            gameObject.SetActive(true);
        }
    }
}
