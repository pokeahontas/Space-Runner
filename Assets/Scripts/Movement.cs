using System.Collections;
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
                StartCoroutine(ChangeSpeedOverTime(60, 0.1f));
                pos = GameObject.FindGameObjectWithTag("Ship2").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);
                
            }
            else
            {
                StartCoroutine(ChangeSpeedOverTime(60,0.1f));
                pos = GameObject.FindGameObjectWithTag("Ship1").transform.position;
                transform.position = new Vector3(pos.x - 15f, pos.y, pos.z);
                
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeSpeedOverTime(float newSpeed, float duration)
    {
             
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            MaxSpeed = newSpeed;
            yield return new WaitForSeconds(0.2f);
        }
        MaxSpeed = 40;
    }

    IEnumerator Speedboost(float duration)
    {

        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            MaxSpeed = MaxSpeed+30;
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

    IEnumerator IncreaseValueOverTime()
    {
        
        while (boostAmount < 1f)
        {
            boostAmount += 0.05f;
            yield return new WaitForSeconds(0.5f);
        }
        boostAmount = 1.0f;
    }

}
