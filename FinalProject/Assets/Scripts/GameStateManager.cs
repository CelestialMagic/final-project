using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action TempGameOver;  //You can ignore this for now - we will talk about Actions a bit later in this course.

    public static float ObstacleMoveSpeed { get; private set; } //A read only global property that makes it easy for us to change the move speed of the obstacles
                                                                //.
    public static float VerticalMoveSpeed { get; private set; } //A global variable that allows us to change the vertical speed of floating obstacles

    public static bool CanSpawn { get; private set; }//A global boolean representing when obstacle spawners can spawn.

    private static float savedObstacleMove;//Used to save the obstacle speed from scene to scene (prevents reset)

    private static float savedVerticalMove;//Used to save the vertical move speed from scene to scene (prevents reset) 



    [SerializeField]
    private AudioClip m_DieSound;//Represents hit an object sound effect

    [SerializeField]
    private AudioClip m_MenuMusic;//Represents menu music

    [SerializeField]
    private AudioClip m_GameMusic;//Represents gameplay music

    [SerializeField] 
    private float verticalSpeed;//Used to control the speed of floating obstacles

    [SerializeField]
    private float obstacleMovespeed; //This field is exposed in the editor but private to the class, this allows us to adjust the move speed of the pilars in the editor

    //[SerializeField]
    //private List<String> m_Levels = new List<string>(); // A list of levels in the form of strings

    [SerializeField]
    private string m_TitleSceneName;//A string representing the name of the Title Scene

    [SerializeField]
    private string m_HighScoreSceneName; //A string representing high score scene

    [SerializeField]
    private string m_FinalScoreScene; //A string representing the final score scene

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
        GAMEOVER,
        FINALSCORE

    }



    // Start is called before the first frame update
    void Start()
    {
        //Singleton Code
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

        ObstacleMoveSpeed = obstacleMovespeed;
        VerticalMoveSpeed = verticalSpeed;
        savedObstacleMove = obstacleMovespeed;
        savedVerticalMove = verticalSpeed;
        CanSpawn = true; 
        m_State = GAMESTATE.MENU;

    }


    //LevelGameOver() is eventually going to be used to advance between levels.
    //It is not a final game over, but rather, a pause to let players advance. 
    public static void LevelGameOver()
    {
        m_State = GAMESTATE.GAMEOVER;
        ObstacleMoveSpeed = 0;
        VerticalMoveSpeed = 0;
        CanSpawn = false;
        SoundManager.PlaySFX(_instance.m_DieSound);
    }

    //Update() method contains the pause code
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.TogglePause();
        }
        
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
            m_State = GAMESTATE.PLAYING;
            ObstacleMoveSpeed = savedObstacleMove;
            VerticalMoveSpeed = savedVerticalMove;
            CanSpawn = true;
            SoundManager.PlayMusic(_instance.m_GameMusic);
            


        }
        
    }

    //A method used to carry out the gameover sequence and display
    public static void FinalScoreScene()
    {
        GameOver();
        SceneManager.LoadScene(_instance.m_FinalScoreScene);

    }

    //StartGame() is used to start the game.
    public static void StartGame()
    {
        m_State = GAMESTATE.PLAYING;
        NextLevel();
    }

    //TogglePause() is used to pause and unpause the game
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

    //Menu() loads the menu screen
    public static void Menu()
    {
        m_State = GAMESTATE.MENU; 
        SceneManager.LoadScene(_instance.m_TitleSceneName);
        SoundManager.PlayMusic(_instance.m_MenuMusic);

    }

    //HighScoreMenu() loads the high score screen
    public static void HighScoreMenu()
    {
        m_State = GAMESTATE.MENU;
        SceneManager.LoadScene(_instance.m_HighScoreSceneName);

    }

    //StoreScore() is called by the PlayerController to track the level score
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

    //CalculateFinalScore() calculates the final score
    public static void CalculateFinalScore()
    {
        finalScore = runScore + swimScore + cycleScore;
    }

    //GameOver() acts as the procedure for the final game over (all three levels)
    public static void GameOver()
    {
        CalculateFinalScore();
        m_State = GAMESTATE.FINALSCORE;
        PlayerPrefs.SetFloat("Score", finalScore);
    }

    
}





