using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //hello
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameStateManager.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
