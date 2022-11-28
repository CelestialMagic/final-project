using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMenu : StartMenu
{
    // Start is called before the first frame update
  
    //Awake() initially deactivates the menu
    private void Awake()
    {
        gameObject.SetActive(false);
        GameStateManager.TempGameOver += Open;
    }

    //Used to open the menu
    private void Open()
    {
        gameObject.SetActive(true);
    }

   
    public void OnDestroy()
    {
        GameStateManager.TempGameOver -= Open;
    }

    //Return to Main Menu 
    public void MainMenu()
    {
        MenuReturn();
    }

    //Used to replay a level
    public void Replay()
    {
        Restart();
    }

    //Used to load the next playable level
    public void NextLevel()
    {
        GameStateManager.NextLevel();
    }

    //Used to load the final score scene
    public void FinalNextLevel()
    {
        GameStateManager.FinalScoreScene();
    }
   

}
