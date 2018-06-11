﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speedForce;
    public bool ship1;
    public bool ship2;

    public float Speed;
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    public bool onGround;

    public GameObject shot;
    public Transform shotSpawn;
    private bool hasLaser;

    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);
        hasLaser = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Speed * Time.deltaTime, 0, 0);

        print(Speed);

        if (ship1)
        {
            if ((Input.GetAxis("Acceleration_J1") > 0))
            {
                if (Speed < MaxSpeed)
                {
                    Speed += Acceleration * Input.GetAxis("Acceleration_J1");
                }
                if (Speed > MaxSpeed)
                {
                    Speed = MaxSpeed;
                }
            }
            else
            {
                if (Speed > Deceleration)
                {
                    Speed = Speed - Deceleration;
                }
                else
                {
                   Speed = 0.0f;
                }

            }
        
        /*
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * speedForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.right * speedForce);
        }
        */
        if (Input.GetAxis("Gravity_J1")<-0.1f && GetComponent<Rigidbody2D>().gravityScale == 1)
            {
                    onGround = false;
                    Debug.Log("flipped gravity");
                    GetComponent<Rigidbody2D>().gravityScale = -1;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            }

        if (Input.GetAxis("Gravity_J1") > 0.1f && GetComponent<Rigidbody2D>().gravityScale == -1)
            {
                    onGround = false;
                    Debug.Log("normal gravity");
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }

            if (Input.GetButton("Fire1") && hasLaser)       //TODO has to be set correctly for controller
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
            }
        }

        

        if (ship2)
        {
            /*
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * speedForce);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(-transform.right * speedForce);
            }
            */
            if ((Input.GetAxis("Acceleration_J2") > 0))
            {
                if (Speed < MaxSpeed)
                {
                    Speed += Acceleration * Input.GetAxis("Acceleration_J2");
                }
                if (Speed > MaxSpeed)
                {
                    Speed = MaxSpeed;
                }
            }
            else
            {
                if (Speed > Deceleration)
                {
                    Speed = Speed - Deceleration;
                }
                else
                {
                    Speed = 0.0f;
                }
            }

         if (Input.GetAxis("Gravity_J2") < -0.1f && GetComponent<Rigidbody2D>().gravityScale == 1)
             {
                    onGround = false;
                    Debug.Log("normal gravity");
                    GetComponent<Rigidbody2D>().gravityScale = -1;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }

            if (Input.GetAxis("Gravity_J2") > 0.1f && GetComponent<Rigidbody2D>().gravityScale == -1)
            {
                    onGround = false;
                    Debug.Log("flipped gravity");
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            }
            if (Input.GetButton("Fire2") && hasLaser)     //TODO has to be set correctly for controller
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
            }
        }
        /*
                if(Input.GetButton("Accelerate"))
                {
                    GetComponent<Rigidbody2D>().AddForce(transform.right * speedForce);
                }
                if (Input.GetButton("Brakes"))
                {
                    GetComponent<Rigidbody2D>().AddForce(-transform.right * speedForce);
                }
                //if (Input.GetButtonDown("Gravity"))
                if (Input.GetKeyDown("space"))
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
                */
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        else if (collision.gameObject.tag == "Laser1")
        {
            Debug.Log("Laserhit");
            Destroy(collision.gameObject);
            StartCoroutine(ChangeSpeedOverTime(20));
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speedboost")
        {
            Debug.Log("Speedboost");
            StartCoroutine(ChangeSpeedOverTime(70));
        }
        else if (collision.gameObject.tag == "Slow")
        {
            Debug.Log("Slow");
            StartCoroutine(ChangeSpeedOverTime(30));
        }
        else if (collision.gameObject.tag == "LaserCollectible")
        {
            Debug.Log("Laser picked up");
            hasLaser = true;
        }
        else if (collision.gameObject.tag == "LaserBarrier")
        {
            Debug.Log("LaserBarrier");
            StartCoroutine(ChangeSpeedOverTime(5));
        }
    }

    IEnumerator ChangeSpeedOverTime(float speed)
    {
        float duration = 0.1f;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            MaxSpeed = speed;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed = 50;
    }
}
