using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMenu : StartMenu
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //Hides the menu
      
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        GameStateManager.TempGameOver += Open;
    }

    private void Open()
    {
        gameObject.SetActive(true);
    }

    public void OnDestroy()
    {
        GameStateManager.TempGameOver -= Open;
    }

    public void MainMenu()
    {
        MenuReturn();
    }

    public void Replay()
    {
        Restart();
    }

    public void NextLevel()
    {
        GameStateManager.NextLevel();
    }
   

}
