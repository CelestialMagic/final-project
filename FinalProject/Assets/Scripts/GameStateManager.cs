using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action TempGameOver;  //You can ignore this for now - we will talk about Actions a bit later in this course.
    public static float ObstacleMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the pillars.

   
    [SerializeField]
    private float obstacleMovespeed; //This field is exposed in the editor but private to the class, this allows us to adjust the move speed of the pilars in the editor

    //[SerializeField]
    //private List<String> m_Levels = new List<string>(); // A list of levels in the form of strings

    [SerializeField]
    private string m_TitleSceneName;//A string representing the name of the Title Scene

    private static GAMESTATE m_State; //The current game state

    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.

    private static float runScore; //Represents score from running level

    private static float swimScore; //Represents score from swimming level

    private static float cycleScore; //Represents score from cycling level

    private static float finalScore; //Represents score from all three games combined

    //An enum that represents the game states. 
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
        ObstacleMoveSpeed = obstacleMovespeed;
        m_State = GAMESTATE.MENU;


    }

    ////GetGameState() was created with the intention of retrieving the game state
    ////from the GameStateManager. It uses a switch statement. 
    //public static string GetGameState(){

    //    return m_State switch
    //    {
    //        GAMESTATE.PLAYING => "PLAYING",
    //        GAMESTATE.PAUSED => "PAUSED",
    //        GAMESTATE.MENU => "MENU",
    //        GAMESTATE.GAMEOVER => "GAMEOVER",
    //        _ => "N/A",
    //    };
    //}

    //LevelGameOver() is eventually going to be used to advance between levels.
    //It is not a final game over, but rather, a pause to let players advance. 
    public static void LevelGameOver()
    {
        m_State = GAMESTATE.GAMEOVER;
        ObstacleMoveSpeed = 0;
    }



    //ResetScene() is responsible for resetting the current scene through a reload.
    public static void ResetScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_State = GAMESTATE.PLAYING;
    }

  

    //Used to advance to the next scene
    public static void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    //StartGame() is used to start the game.
    
    public static void StartGame()
    {
        m_State = GAMESTATE.PLAYING;
        NextLevel();
    }

    //TogglePause() will be used later to pause the game. 
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

    //Menu() changes the game state to MENU. It then loads the first scene,
    //which is the title screen/main menu.
    public static void Menu()
    {
        m_State = GAMESTATE.MENU; 
        SceneManager.LoadScene(_instance.m_TitleSceneName);

    }

    public static void StoreScore(float levelScore)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                runScore = levelScore;
                break;
            case 2:
                swimScore = levelScore;
                break;
            case 3:
                cycleScore = levelScore;
                break;
            default:
                break;

        }
    }
}





