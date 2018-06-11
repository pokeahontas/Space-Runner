using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyboard : MonoBehaviour
{

    public float speedForce;
    public bool ship1;
    public bool ship2;

    public float Speed;
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    public bool onGround;

    public GameObject shot1;
    public GameObject shot2;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    private bool hasLaserP1;
    private bool hasLaserP2;

    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);
        hasLaserP1 = true;
        hasLaserP2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
        Debug.Log(MaxSpeed);

        if (ship1)
        {
            if ((Input.GetKey(KeyCode.D)))
            {
                if (Speed < MaxSpeed)
                {
                    Speed += Acceleration;
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
            if (Input.GetKeyDown(KeyCode.W) && GetComponent<Rigidbody2D>().gravityScale == 1)
            {
                onGround = false;
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                //GetComponent<SpriteRenderer>().flipY = true;
                GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                //GetComponent<PolygonCollider2D>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
            }

            if (Input.GetKeyDown(KeyCode.S) && GetComponent<Rigidbody2D>().gravityScale == -1)
            {
                onGround = false;
                Debug.Log("normal gravity");

                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().AddForce(-transform.right * speedForce);
                }

                if (Input.GetKeyDown(KeyCode.W) && GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    onGround = false;
                    Debug.Log("flipped gravity");
                    GetComponent<Rigidbody2D>().gravityScale = -1;
                    //GetComponent<SpriteRenderer>().flipY = true;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                    //GetComponent<PolygonCollider2D>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                }

                if (Input.GetKeyDown(KeyCode.S) && GetComponent<Rigidbody2D>().gravityScale == -1)
                {
                    onGround = false;
                    Debug.Log("normal gravity");
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    //GetComponent<SpriteRenderer>().flipY = false;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                }
            }

            if(Input.GetKeyDown(KeyCode.Q) && hasLaserP1)
            {
                Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation);
                hasLaserP1 = false;
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
                if ((Input.GetKey(KeyCode.RightArrow)))
                {
                    if (Speed < MaxSpeed)
                    {
                        Speed += Acceleration;
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

                if (Input.GetKeyDown(KeyCode.UpArrow) && GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    onGround = false;
                    Debug.Log("normal gravity");
                    GetComponent<Rigidbody2D>().gravityScale = -1;
                    //GetComponent<SpriteRenderer>().flipY = false;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, 0.7f, 1f);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponent<Rigidbody2D>().gravityScale == -1)
                {
                    onGround = false;
                    Debug.Log("flipped gravity");
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    //GetComponent<SpriteRenderer>().flipY = true;
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                    //GetComponent<PolygonCollider2D>().transform.localScale = new Vector3(0.7f, -0.7f, 1f);
                }

            if (Input.GetKey(KeyCode.P) && hasLaserP2)
            {
                Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
                hasLaserP2 = false;
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speedboost")
        {
            Debug.Log("Speedboost");
            StartCoroutine(ChangeSpeedOverTime(70));
        } else if(collision.gameObject.tag == "Slow")
        {
            Debug.Log("Slow");
            StartCoroutine(ChangeSpeedOverTime(30));
        } else if(collision.gameObject.tag == "Laser")
        {
            Debug.Log("Laser picked up");
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
