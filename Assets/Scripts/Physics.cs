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
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject));
                        //Destroy(collision.gameObject);
                    }
                    else
                    {
                        
                    }
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
                    if (!this.gameObject.GetComponent<Movement>().onGround)
                    {
                        StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject));
                        //Destroy(collision.gameObject);
                    }
                    else
                    {
                       
                    }
                }
            }
        }
    }

    IEnumerator DoBlinks(float duration, float blinkTime, GameObject go)
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

        //make sure renderer is enabled when we exit
        go.GetComponent<Renderer>().enabled = true;

        //set the destroyed ship only a little back of the other one
        //really needed?
        //go.transform.position = new Vector3(this.gameObject.transform.position.x - 15f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
