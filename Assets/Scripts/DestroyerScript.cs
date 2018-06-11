using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

    public GameObject ship1;
    public GameObject ship2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ship1??false)
        {
            if (ship2??false)
            {
                transform.position = new Vector3(Mathf.Min(ship1.transform.position.x, ship2.transform.position.x) - 300, transform.position.y, transform.position.z);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
