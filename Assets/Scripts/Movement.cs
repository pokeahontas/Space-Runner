using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float speedForce;
    public bool ship1;
    public bool ship2;

    public float Speed;
    private float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    public bool onGround;

    public GameObject shot;
    public Transform shotSpawn;
    private bool hasLaser;
    public bool start;

    public int leben;

    public Text hp;

    void Start()
    {
        //Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);
        hasLaser = false;
        start = false;
        leben = 3;
        hp.text = "HP: " + leben;
        MaxSpeed = 40.0f;
    }

    // Update is called once per frame
    void Update()
    {

        
        hp.text = "HP: " + leben;
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

            if (Input.GetButton("Fire1") && hasLaser)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
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
            if (Input.GetButton("Fire2") && hasLaser)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                hasLaser = false;
            }
        }
    }

    void Accelerate(string s)
    {
        if (Speed < MaxSpeed)
        {
            Speed += Acceleration * Input.GetAxis(s);
        }
        if (Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    void DeAccelerate()
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        else if (collision.gameObject.tag == "Laser1")
        {
            Debug.Log("Laserhit");
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
            StartCoroutine(ChangeSpeedOverTime(25));
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
            StartCoroutine(ChangeSpeedOverTime(5));
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
                StartCoroutine(ChangeSpeedOverTime(60));
                pos = GameObject.FindGameObjectWithTag("Ship2").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);
                
            }
            else
            {
                StartCoroutine(ChangeSpeedOverTime(60));
                pos = GameObject.FindGameObjectWithTag("Ship1").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);
                
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeSpeedOverTime(float newSpeed)
    {
        float duration = 0.1f;
       
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            MaxSpeed = newSpeed;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed = 40;
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
    
}
