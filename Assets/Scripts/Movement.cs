﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public bool ship1;
    public bool ship2;

    public float Speed;
    private float MaxSpeed;

    public bool onGround;

    public GameObject shot;
    public Transform shotSpawn;
    private bool hasLaser;
    public bool start;

    private float boostAmount;
    public Image boostBar;

    public int leben;
    public Sprite[] heartSprites;
    public Image heartsImage;

    public bool hasCollide = false;

    public Text hp;

    void Start()
    {
        //Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);
        hasLaser = false;
        start = false;
        leben = 3;
        heartsImage.sprite = heartSprites[2];
        //hp.text = "HP: " + leben;
        MaxSpeed = 40.0f;
        boostAmount = 1.0f;
        hasCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(leben > 0) { 
        heartsImage.sprite = heartSprites[leben-1];
            }
        //hp.text = "HP: " + leben;
        boostBar.fillAmount = this.boostAmount;
        transform.Translate(Speed * Time.deltaTime, 0, 0);

        //print(Speed);

        if (ship1)
        {
            if (leben <= 0)
            {
                SceneManager.LoadScene("P2Won");
            }
            if ((Input.GetAxis("Acceleration_J1") > 0) && start)
            {
                Accelerate("Acceleration_J1");
            }
            else
            {
                DeAccelerate();
            }

            if (Input.GetAxis("Gravity_J1") < -0.1f && GetComponent<Rigidbody2D>().gravityScale == 1 && onGround && start)
            {
                onGround = false;
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            }

            if (Input.GetAxis("Gravity_J1") > 0.1f && GetComponent<Rigidbody2D>().gravityScale == -1 && onGround && start)
            {
                onGround = false;
                Debug.Log("normal gravity");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }
            /*
            if (Input.GetButton("Fire1") && hasLaser)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
            }
            */
            if (Input.GetButton("Boost1") && boostAmount >= 1 && ship1)
            {
                StartCoroutine(Speedboost(0.05f));
                boostAmount = 0;
                StartCoroutine(IncreaseValueOverTime());
                print("boost1 "+ship1);
            }
        }


        if (ship2)
        {
            if (leben <= 0)
            {
                SceneManager.LoadScene("P1Won");
            }

            if ((Input.GetAxis("Acceleration_J2") > 0) && start)
            {
                Accelerate("Acceleration_J2");
            }
            else
            {
                DeAccelerate();
            }

            if (Input.GetAxis("Gravity_J2") < -0.1f && GetComponent<Rigidbody2D>().gravityScale == 1 && onGround && start)
            {
                onGround = false;
                Debug.Log("normal gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            }

            if (Input.GetAxis("Gravity_J2") > 0.1f && GetComponent<Rigidbody2D>().gravityScale == -1 && onGround && start)
            {
                onGround = false;
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            }
            /*
            if (Input.GetButton("Fire2") && hasLaser)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
            }
            */
            if (Input.GetButton("Boost2") && boostAmount >= 1 && ship2) 
            {
                StartCoroutine(Speedboost(0.05f));
                boostAmount = 0;
                StartCoroutine(IncreaseValueOverTime());
            }
        }
    }

    void Accelerate(string s)
    {
        if (Speed < MaxSpeed)
        {
            Speed += 1.0f * Input.GetAxis(s);
        }
        if (Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    void DeAccelerate()
    {
        if (Speed > 1.0f)
        {
            Speed = Speed - 1.0f;
        }
        else
        {
            Speed = 0.0f;
        }
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
            StartCoroutine(ChangeSpeedOverTime(20, 0.1f));
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speedboost")
        {
            Debug.Log("Speedboost");
            StartCoroutine(ChangeSpeedOverTime(70, 0.1f));
        }
        else if (collision.gameObject.tag == "Slow")
        {
            Debug.Log("Slow");
            StartCoroutine(ChangeSpeedOverTime(25, 0.1f));
        }
        else if (collision.gameObject.tag == "LaserCollectible")
        {
            Debug.Log("Laser picked up");
            hasLaser = true;
            StartCoroutine(DoBlinks(0.1f, 0.2f, collision.gameObject));
        }
        else if (collision.gameObject.tag == "LaserBarrier")
        {
            Debug.Log("LaserBarrier");
            StartCoroutine(ChangeSpeedOverTime(5, 0.1f));
        }
        else if (collision.gameObject.tag == "Goal")
        {
            if (ship1)
            {
                SceneManager.LoadScene("P1Won");
            }
            if (ship2)
            {
                SceneManager.LoadScene("P2Won");
            }
        }
        else if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("Portal");
            Vector3 pos;
            if (ship1)
            {
                StartCoroutine(ChangeBoostOverTime(30, 0.1f));
                pos = GameObject.FindGameObjectWithTag("Ship2").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);

            }
            else
            {
                StartCoroutine(ChangeBoostOverTime(30, 0.1f));
                pos = GameObject.FindGameObjectWithTag("Ship1").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);

            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Back1")
        {
            print("Back1");
            if (ship2)
            {
                if (hasCollide == false)
                {
                    print("Back1Inner");
                    hasCollide = true;
                    StartCoroutine(BackDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Back2")
        {
            print("Back2");
            if (ship1)
            {
                if (hasCollide == false)
                {
                    print("Back2Inner");
                    hasCollide = true;
                    StartCoroutine(BackDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Top1")
        {
            print("Top1");
            if (ship2)
            {
                if (hasCollide == false)
                {
                    print("Top1Inner");
                    hasCollide = true;
                    StartCoroutine(TopDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Top2")
        {
            print("Top2");
            if (ship1)
            {
                if (hasCollide == false)
                {
                    print("Top2Inner"); 
                    hasCollide = true;
                    StartCoroutine(TopDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
    }

    IEnumerator ChangeSpeedOverTime(float newSpeed, float duration)
    {
        float oldSpeed = MaxSpeed;
        while (duration > 0f)
        {
            MaxSpeed = newSpeed;
            duration -= Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed -= (newSpeed - oldSpeed);
    }

    IEnumerator ChangeBoostOverTime(float plusSpeed, float duration)
    {
        MaxSpeed += plusSpeed;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed -= plusSpeed;
    }

    IEnumerator Speedboost(float duration)
    {
        MaxSpeed +=  30;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed -= 30;
    }

    IEnumerator DoBlinks(float duration, float blinkTime, GameObject go)
    {

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
    }

    IEnumerator IncreaseValueOverTime()
    {
        
        while (boostAmount < 1f)
        {
            boostAmount += 0.05f;
            yield return new WaitForSeconds(0.5f);
        }
        boostAmount = 1.0f;
    }

    IEnumerator BackDamage(float duration, float blinkTime, GameObject go, bool minusHP)
    {
        go.GetComponent<Movement>().hasCollide = true;
        go.GetComponent<Movement>().Speed = 0;
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = false;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;

        if (minusHP)
        { 
            go.GetComponent<Movement>().leben--;
        }

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
        hasCollide = false;
        go.GetComponent<Movement>().hasCollide = false;
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = true;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator TopDamage(float duration, float blinkTime, GameObject go, bool minusHP)
    {
        go.GetComponent<Movement>().hasCollide = true;
        go.GetComponent<Movement>().Speed = 0;
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = false;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;

        if (minusHP)
        {
            go.GetComponent<Movement>().leben--;
        }

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
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = true;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = true;
        hasCollide = false;
        go.GetComponent<Movement>().hasCollide = false;
    }

}
