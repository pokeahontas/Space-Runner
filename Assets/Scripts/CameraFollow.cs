﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ship1;
    public GameObject ship2;

	
	
    public float cameraSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1,0,0) * cameraSpeed * Time.deltaTime);

        //Follow the ship that is further ahead
        //if (ship1.transform.position.x > ship2.transform.position.x)
        //{
        //    if (ship1 ?? false)
        //    {
        //        this.transform.position = new Vector3(ship1.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
        //    }
        //}
        //else
        //{
        //    if (ship2 ?? false)
        //    {
        //        this.transform.position = new Vector3(ship2.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
        //    }
        //}
    }
}
