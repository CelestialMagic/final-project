using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwimmingController : PlayerController
{
    
    //Overrides the Update() method from Parent class PlayerController
    protected override void Update()
    {
       //Player can move right with D
        if (Input.GetKey(KeyCode.D))
        {
            m_ToApplyMove += new Vector3(m_SpeedForce * Time.deltaTime, 0, 0);
        }

        //Player can move left with A
        if (Input.GetKey(KeyCode.A))
        {
            m_ToApplyMove += new Vector3(-m_SpeedForce * Time.deltaTime, 0, 0);
        }
        
        UsePowerUp();
        IncreaseScore();
    }
    
}
