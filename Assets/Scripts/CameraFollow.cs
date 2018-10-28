using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ship1;
    public GameObject ship2;

    //public float cameraSpeed;
    //public bool ship1Ahead;
    
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(1,0,0) * cameraSpeed * Time.deltaTime); uncomment for automatic camera movement

        //Follow the ship that is further ahead
        if (ship1.transform.position.x > ship2.transform.position.x)
        {
            if (ship1 ?? false)
            {
                //ship1Ahead = true;
                //this.transform.position = new Vector3(ship1.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
                MoveCameraToTargetPos(new Vector3(ship1.transform.position.x + 2f, this.transform.position.y, this.transform.position.z));
            }
        }
        else
        {
            if (ship2 ?? false)
            {
                //ship1Ahead = false;
                //this.transform.position = new Vector3(ship2.transform.position.x + 2f, this.transform.position.y, this.transform.position.z
                MoveCameraToTargetPos(new Vector3(ship2.transform.position.x + 2f, this.transform.position.y, this.transform.position.z));

            }
        }
    }

    void MoveCameraToTargetPos(Vector3 targetPos)
    {
        Vector3 velocity = Vector3.zero;
        this.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.24F);
    }
}
