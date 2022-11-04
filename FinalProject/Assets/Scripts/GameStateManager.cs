using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class GameStateManager : MonoBehaviour
{
    //public static Action OnGameOver;  //You can ignore this for now - we will talk about Actions a bit later in this course.
    public static float ObstacleMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the pillars.

    [SerializeField]
    private GameObject GameOverScreen; //A reference to the GameObject that is the GameOver UI Screen
    [SerializeField]
    private float obstacleMoveSpeed; //This field is exposed in the editor but private to the class, this allows us to adjust the move speed of the pilars in the editor

    [SerializeField]
    private List<String> m_Levels = new List<string>();

    [SerializeField]
    private string m_TitleSceneName;

    private static GAMESTATE m_State;

    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.


    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }



    // Start is called before the first frame update
    void Start()
    {
        //Setup for making this class a Singlton - Don't modify this part of the code.
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }


        //Put other inialization for you game state here
        ObstacleMoveSpeed = obstacleMoveSpeed;
        m_State = GAMESTATE.MENU;


    }

    public static string GetGameState(){

        return m_State switch
        {
            GAMESTATE.PLAYING => "PLAYING",
            GAMESTATE.PAUSED => "PAUSED",
            GAMESTATE.MENU => "MENU",
            GAMESTATE.GAMEOVER => "GAMEOVER",
            _ => "N/A",
        };
    }


    //Alpha Playtest GameOver() code
    public static void LevelGameOver()
    {

        //Add any logic that you would want to do when the game ends here
        //This invokes the game over screen - here we are calling all the methods that subscribed to this action.
        //OnGameOver();
        Debug.Log(m_State);
        m_State = GAMESTATE.GAMEOVER;
        Debug.Log(m_State);
        ObstacleMoveSpeed = 2;
        Menu();
    }

    public static void ResetScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_State = GAMESTATE.PLAYING;
    }

    public static void GameOver()
    {

        //Add any logic that you would want to do when the game ends here
        //This invokes the game over screen - here we are calling all the methods that subscribed to this action.
        m_State = GAMESTATE.MENU; 
        SceneManager.LoadScene(_instance.m_TitleSceneName);

    }

    //Used to advance to the next scene 
    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public static void StartGame()
    {
        m_State = GAMESTATE.PLAYING;
        NextLevel();
    }

    public static void TogglePause()
    {
        if(m_State == GAMESTATE.PLAYING)
        {
            m_State = GAMESTATE.PAUSED;
            Time.timeScale = 0;
        } else if (m_State == GAMESTATE.PAUSED)
        {
            m_State = GAMESTATE.PLAYING;
            Time.timeScale = 1; 
        }
    }

    public static void Menu()
    {
        m_State = GAMESTATE.MENU; 
        SceneManager.LoadScene(0);

    }
}





