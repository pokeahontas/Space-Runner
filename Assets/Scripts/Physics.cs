using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {

    public bool ship1;
    public bool ship2;

    public bool hasCollide = false;

    //public GameObject otherShip;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}


    /*
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (ship1)
        {   
            //Collision with other ship from above
            if (collision.gameObject.tag == "Ship2" )
            {
                print("collision");
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        if (hasCollide == false)
                        {
                            hasCollide = true;
                            StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
                        }
                    }
                    else
                    {
                        if (collision.gameObject.transform.position.x > this.gameObject.transform.position.x)
                        {
                            if (hasCollide == false)
                            {
                                collision.gameObject.GetComponent<Physics>().hasCollide = true;
                                hasCollide = true;
                                StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
                            }
                        }
                    }
                }
            }

        }
        else
        {
            //Collision with other ship from above
            if (collision.gameObject.tag == "Ship1" )
            {
                print("collision");
                if (collision.gameObject.GetComponent<Movement>().onGround)
                {
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        if (hasCollide == false)
                        {
                            hasCollide = true;
                            StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
                        }
                    }
                    else
                    {
                        if (collision.gameObject.transform.position.x > this.gameObject.transform.position.x)
                        {
                            if (hasCollide == false)
                            {
                                collision.gameObject.GetComponent<Physics>().hasCollide = true;
                                hasCollide = true;
                                StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
                            }
                        }
                    }
                }
            }
            /*
            if (collision.gameObject.tag == "Back1")
            {
                if (hasCollide == false)
                {
                    hasCollide = true;
                    StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject, true));
                }
            }
            */
//        }
//    }
    
    
    IEnumerator DoBlinks(float duration, float blinkTime, GameObject go, bool minusHP)
    {
        go.GetComponent<Movement>().Speed = 0;

        if (minusHP)
        {
            //go.GetComponent<Movement>().leben--;
        }

        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            go.GetComponent<Renderer>().enabled = !go.GetComponent<Renderer>().enabled;

            

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }



        //make sure renderer is enabled when we exit
        go.GetComponent<Renderer>().enabled = true;
        hasCollide = false;
        go.GetComponent<Physics>().hasCollide = false;

        //set the destroyed ship only a little back of the other one
        //really needed?
        //go.transform.position = new Vector3(this.gameObject.transform.position.x - 15f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
