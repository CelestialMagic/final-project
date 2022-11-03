using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected AudioClip m_JumpSound;

    [SerializeField]
    protected AudioSource m_AudioSource;

    [SerializeField]
    protected float m_JumpForce;

    [SerializeField]
    protected float m_SpeedForce;

    [SerializeField]
    protected Rigidbody2D m_Rigidbody;

    protected Vector3 m_ToApplyMove;

    protected Animator m_Anim;
    protected SpriteRenderer m_Renderer;

    [SerializeField]
    protected float jumpHeight;

    protected float score;

    protected float scoreTimer;

    [SerializeField]
    protected float scoreDelay; 

    //A list of ints representing powerUp IDs. 
    protected List<PowerUp> powerUps; 

    // Start is called before the first frame update
    void Start()
    { 
        m_Renderer = GetComponent<SpriteRenderer>();
        powerUps = new List<PowerUp>();
        scoreTimer = 0f;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //This code allows for a single jump, as the player can only jump again
        //when the space key is pressed and the y-position is less than or equal
        //to the jumpHeight. This also limits how high the player can jump.
        if (Input.GetKey(KeyCode.Space) && gameObject.transform.position.y <= jumpHeight)
        {
            m_ToApplyMove += new Vector3(0, m_JumpForce, 0);
            
        }
        
        UsePowerUp();
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
        scoreTimer += Time.deltaTime;

        if(scoreTimer >= scoreDelay)
        {
            scoreTimer = 0f;
            score++; 
        }
    }

    //Returns the score of the player. 
    public float GetScore()
    {
        return score;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            GameStateManager.Menu();

        }
    }
}
