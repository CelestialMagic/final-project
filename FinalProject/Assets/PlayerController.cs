using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_JumpSound;

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private float m_SpeedForce;

    [SerializeField]
    private float m_JumpForce;

    [SerializeField]
    private Rigidbody2D m_Rigidbody;

    private Vector3 m_ToApplyMove;

    private Animator m_Anim;
    private SpriteRenderer m_Renderer;

    [SerializeField]
    private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        //if (m_Anim != null)
        //{
        //    m_Anim.SetBool("Ground", true);
        //    m_Anim.SetFloat("Speed", 0);
        //}

        m_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Potential Swim Code
        //if (Input.GetKey(KeyCode.D)){
        //    m_ToApplyMove += new Vector3(m_SpeedForce, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    m_ToApplyMove += new Vector3(-m_SpeedForce, 0, 0);
        //}

        if (Input.GetKey(KeyCode.Space) && gameObject.transform.position.y <= jumpHeight)
        {
            m_ToApplyMove += new Vector3(0, m_JumpForce, 0);
            
        }
        


    }
    void FixedUpdate()
    {
        
        
            m_Rigidbody.AddForce(m_ToApplyMove);
            m_ToApplyMove = Vector3.zero;
            

        
            
       
           
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
