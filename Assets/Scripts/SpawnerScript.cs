using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public GameObject[] obj;
    public GameObject goal;


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
    void SpawnGoal(Vector3 position)
    {
        Instantiate(goal, position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ship1" || collision.tag == "Ship2")
        {
            print(transform.position.x);
            if (transform.position.x < 2000)
            {
                Spawn(new Vector3(transform.position.x + 100, transform.position.y, transform.position.z));
                transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
            }
            else
            {
                SpawnGoal(new Vector3(transform.position.x + 100, transform.position.y, transform.position.z));
                transform.position = new Vector3(transform.position.x + 500, transform.position.y, transform.position.z);
            }
            
        }
    }
}
