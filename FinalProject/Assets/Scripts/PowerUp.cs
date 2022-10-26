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
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Object.Destroy(gameObject);
        }
        
    }

    //returns the PowerUp ID number
    public int GetID()
    {
        return ID; 
    }

    //returns the PowerUp Icon
    public Sprite GetIcon()
    {
        return icon; 
    }
}
