using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {

    public bool ship1;
    public bool ship2;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (ship1)
        {   
            //Collision with other ship
            if (collision.gameObject.tag == "Ship2" )
            {
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        else
        {
            //Collision with other ship
            if (collision.gameObject.tag == "Ship1" )
            {
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
