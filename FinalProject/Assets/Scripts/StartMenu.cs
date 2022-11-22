using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
  

    //Starts the Game
    protected void StartGame()
    {
        GameStateManager.StartGame();
    }
    //Quits the Game
    protected void QuitGame()
    {
        Application.Quit();
    }

    //Calls the GameStateManager to restart the scene
    protected void Restart()
    {
        GameStateManager.ResetScene();
    }

    //MenuReturn() calls the GameStateManager to update the current Game State
    protected void MenuReturn()
    {
        GameStateManager.Menu(); 
    }

    private void HighScore()
    {
        GameStateManager.HighScoreMenu();
    }

}
