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
        string gameState = GameStateManager.GetGameState();
        Debug.Log(GameStateManager.GetGameState());
        if (gameState == "GAMEOVER")
        {
            gameObject.SetActive(true);
        }
    }
}
