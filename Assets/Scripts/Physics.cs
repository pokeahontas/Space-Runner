using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {

    public bool ship1;
    public bool ship2;

    //public GameObject otherShip;


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
            //Collision with other ship from above
            if (collision.gameObject.tag == "Ship2" )
            {
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject,true));
                    }
                    else
                    {
                        
                    }
                }
            }
            if (collision.gameObject.tag == "Back2")
            {
                StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
            }

        }
        else
        {
            //Collision with other ship from above
            if (collision.gameObject.tag == "Ship1" )
            {
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject,true));
                    }
                    else
                    {
                       
                    }
                }
            }
            if (collision.gameObject.tag == "Back1")
            {
                StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
            }
        }
    }

    IEnumerator DoBlinks(float duration, float blinkTime, GameObject go, bool minusHP)
    {
        go.GetComponent<Movement>().Speed = 0;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            go.GetComponent<Renderer>().enabled = !go.GetComponent<Renderer>().enabled;

            

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        if (minusHP)
        {
            go.GetComponent<Movement>().leben -= 1;
        }

        //make sure renderer is enabled when we exit
        go.GetComponent<Renderer>().enabled = true;

        //set the destroyed ship only a little back of the other one
        //really needed?
        //go.transform.position = new Vector3(this.gameObject.transform.position.x - 15f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
