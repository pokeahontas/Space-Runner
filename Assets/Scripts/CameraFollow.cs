using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ship;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(target.position.x + 8f, target.position.y + 3f, -10f);
        this.transform.position = new Vector3(ship.transform.position.x+15f, this.transform.position.y, this.transform.position.z);
    }
}
