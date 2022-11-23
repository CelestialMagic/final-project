using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected BackgroundMover background;//Represents the current background

    [SerializeField]
    protected AudioClip m_JumpSound;//A clip representing the player jump sound

    [SerializeField]
    protected AudioSource m_AudioSource;//Audio Source for player

    [SerializeField]
    protected float m_JumpForce;//The force at which the player jumps

    [SerializeField]
    protected float m_SpeedForce;//The speed of a player (used mainly for inheritance in SwimmerController)

    [SerializeField]
    protected Rigidbody2D m_Rigidbody;//The Rigidbody

    protected Vector3 m_ToApplyMove;//A Vector3 representing the player movement force

    protected Animator m_Anim;//The Animator
    protected SpriteRenderer m_Renderer;//The Sprite Renderer

    [SerializeField]
    protected float jumpHeight;// A float representing a height a player must be less than or equal to to jump again. 

    protected float score;//The player score

    protected float scoreTimer;//A timer that tracks when to update the score

    [SerializeField]
    protected float scoreDelay; //A number representing a time to delay the score increment

    protected bool gameOver;//A bool used to determine incrementing score (stops after gameover)

    protected const float divider = 1000; //A constant for kilometer conversion

    //A list of ints representing powerUp IDs. 
    protected List<PowerUp> powerUps;

   

    // Start is called before the first frame update
    void Start()
    { 
        m_Renderer = GetComponent<SpriteRenderer>();
        powerUps = new List<PowerUp>();
        scoreTimer = 0f;
        gameOver = false;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //This code allows for a single jump, as the player can only jump again
        //when the space key is pressed and the y-position is less than or equal
        //to the jumpHeight. This also limits how high the player can jump.
        if (Input.GetKey(KeyCode.Space) && gameObject.transform.position.y <= jumpHeight)
        {
            m_ToApplyMove += new Vector3(0, m_JumpForce *Time.deltaTime, 0);
            
        }

        UsePowerUp();
        //Called to increment the score
        IncreaseScore();

    }

    protected void FixedUpdate()
    {
        //Applies force to rigidbody to allow player to jump
        //Resets to zero after. 
            m_Rigidbody.AddForce(m_ToApplyMove);
            m_ToApplyMove = Vector3.zero;
    }

    
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //When the player collides with a PowerUp, it is added to
        //the powerUps list. 
        if (collision.gameObject.tag == "PowerUp")
        {
            powerUps.Add(collision.gameObject.GetComponent<PowerUp>());

        }

    }

    //UsePowerUp() allows players to activate a power up given that they
    //hit enter/return and have collected at least one powerup. 
    protected void UsePowerUp()
    {
        if (Input.GetKeyDown(KeyCode.Return) && powerUps.Count >= 1)
        {
            //Temporary Tester Code
            this.gameObject.GetComponent<SpriteRenderer>().sprite = powerUps[0].GetIcon();
            powerUps.Remove(powerUps[0]);

        }
    }

    //The score increases each frame after a certain delay.
    //The delay slows down the incremented score to make
    //it feel as though the player is traveling at a certain speed. 
    protected void IncreaseScore()
    {
        if (gameOver == false)
        {
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= scoreDelay)
            {
                scoreTimer = 0f;
                score++;
            }

        }
        
    }

    //Returns the score of the player. 
    public float GetScore()
    {
        return score/divider;
    }

    //OnCollisionEnter2D() is used to detect player collisions
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        //Detects if a player hits an obstacle (tagged "GameOver")
        if (collision.gameObject.tag == "GameOver")
        {

            GameOverProcedure();
            

        }
    }

    //GameOverProcedure() handles the end of each level.
    protected void GameOverProcedure()
    {
        gameOver = true;
        GameStateManager.StoreScore(GetScore());
        GameStateManager.LevelGameOver();
        GameStateManager.TempGameOver();
        m_JumpForce = 0f;
        m_SpeedForce = 0f;
        background.StopMovement();

    }

    
   
}
