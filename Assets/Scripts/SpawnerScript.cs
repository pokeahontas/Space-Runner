using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public GameObject[] obj;
    public GameObject goal;

    public GameObject portal;

    public GameObject ship1;
    public GameObject ship2;


    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnPortal", 5.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SpawnPortal()
    {
        Vector3 position;

        //Random portal at ship1 or ship2
        int i = Random.Range(1, 3);
        if (i == 1)
        {
            position = new Vector3(ship1.transform.position.x+Random.Range(15.0f, 30.0f), Random.Range(3.0f, -3.0f), ship1.transform.position.z);
        }
        else
        {
            position = new Vector3(ship2.transform.position.x + Random.Range(15.0f, 30.0f), Random.Range(3.0f, -3.0f), ship2.transform.position.z);
        }
        
        Instantiate(portal, position, Quaternion.identity);
    }

    void SpawnMap(Vector3 position)
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
            /*
            print(transform.position.x);
            if (transform.position.x < 2000)
            {
            */
                SpawnMap(new Vector3(transform.position.x + 100, transform.position.y, transform.position.z));
                transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
            //}
            /*else
            {
                SpawnGoal(new Vector3(transform.position.x + 100, transform.position.y, transform.position.z));
                transform.position = new Vector3(transform.position.x + 500, transform.position.y, transform.position.z);
            }*/

        }
    }
}
