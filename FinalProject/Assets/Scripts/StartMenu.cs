using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
      
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
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
    protected void MenuReturn()
    {
        GameStateManager.Menu(); 
    }


}
