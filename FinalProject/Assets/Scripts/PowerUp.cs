using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int ID;

    [SerializeField]
    private Sprite icon; 
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PowerUp disappears after touching player
        if(collision.gameObject.tag == "Player")
        {
            Object.Destroy(gameObject);
        }
        
    }

    //GetId() returns the PowerUp ID number
    public int GetID()
    {
        return ID; 
    }

    //GetIcon() returns the PowerUp Icon
    public Sprite GetIcon()
    {
        return icon; 
    }
}
