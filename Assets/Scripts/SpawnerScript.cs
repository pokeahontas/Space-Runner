using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public GameObject[] obj;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn(Vector3 position)
    {
        Instantiate(obj[Random.Range(0, obj.Length)], position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ship1" || collision.tag == "Ship2")
        {
            Spawn(new Vector3(transform.position.x+25,transform.position.y, transform.position.z));
            transform.position = new Vector3(transform.position.x + 25, transform.position.y, transform.position.z);
        }
    }
}
