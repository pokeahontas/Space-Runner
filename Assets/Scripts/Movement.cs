using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speedForce;

	void Start () {
        Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetButton("Accelerate"))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * speedForce);
        }
        if (Input.GetButton("Brakes"))
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.right * speedForce);
        }
        if (Input.GetButtonDown("Gravity"))
        {
            if (GetComponent<Rigidbody2D>().gravityScale == 1) {
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                //GetComponent<SpriteRenderer>().flipY = true;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                //GetComponent<PolygonCollider2D>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            } else
            {
                Debug.Log("normal gravity");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                //GetComponent<SpriteRenderer>().flipY = false;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }
        }
    }
}
