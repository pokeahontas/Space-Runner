using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement2 : MonoBehaviour
{

    public GameObject scoreP1;
    public GameObject scoreP2;

    public GameObject portal;

    private Animator anim;
    public bool ship1;
    public bool ship2;

    public float Speed;
    private float MaxSpeed;

    public bool onGround;
    public bool start;
    public bool hasCollide = false;

    public bool hasPike1;
    public bool hasPike2;
    public bool facingRight;
    public bool hasTurnedAround;

    public GameObject colliderLeft;
    public GameObject goRight;

    public int decAmount;
    public int incAmount;
    

    void Start()
    {
        //Debug.Log(GetComponent<SpriteRenderer>().transform.localScale);
        start = false;

        MaxSpeed = 5.0f;
        hasCollide = false;
        anim = GetComponent<Animator>();

        hasPike1 = false;
        hasPike2 = false;
        facingRight = true;
        hasTurnedAround = true;
        

    }

    void FixedUpdate()
    {

        if(ship1)
        {
            if (Input.GetAxis("Direction_J1") < -0.1f && facingRight && onGround && !hasPike1 && !anim.GetBool("damage"))
            {
                
                SoundManagement.Instance.PlayNote("g", "ship1", true);
                facingRight = false;
                Accelerate("Direction_J1");
                if (GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(-1f, 1f, 1f))); //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(-1f, -1f, 1f))); //GetComponent<SpriteRenderer>().transform.localScale =  new Vector3(-1f, -1f, 1f);
                }
            }
            else if (Input.GetAxis("Direction_J1") > 0.1f && !facingRight && onGround && !hasPike1 && !anim.GetBool("damage"))
            {
                facingRight = true;
                Accelerate("Direction_J1");

                if (GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(1f, 1f, 1f))); //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                { 
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(1f, -1f, 1f))); //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, -1f, 1f);
                }
            } else if(Input.GetAxis("Direction_J1") > 0.1f || Input.GetAxis("Direction_J1") < -0.1f && start && !anim.GetBool("damage"))
            {
                Accelerate("Direction_J1");
                anim.SetBool("isRunning", true);
            } else
            {
                anim.SetBool("isRunning", false);
                DeAccelerate();
            }
        }
        if(ship2)
        {
            if (Input.GetAxis("Direction_J2") < -0.1f && facingRight && onGround && !hasPike2 && !anim.GetBool("damage"))
            {
                SoundManagement.Instance.PlayNote("g", "ship1", true);
                facingRight = false;
                Accelerate("Direction_J2");
                if (GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, 1f, 1f);
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(-1f, -1f, 1f)));
                }
                else
                {
                    //GetComponent<SpriteRenderer>().transform.localScale =  new Vector3(-1f, -1f, 1f);
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(-1f, 1f, 1f)));
                }
            }
            else if (Input.GetAxis("Direction_J2") > 0.1f && !facingRight && onGround && !hasPike2 && !anim.GetBool("damage"))
            {
                facingRight = true;
                Accelerate("Direction_J2");
                if (GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, 1f, 1f);
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(1f, -1f, 1f)));
                }
                else
                {
                    //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, -1f, 1f);
                    StartCoroutine(LerpOverTime(0.1f, new Vector3(1f, 1f, 1f)));
                }
            }
            else if(Input.GetAxis("Direction_J2") > 0.1f || Input.GetAxis("Direction_J2") < -0.1f && start && !anim.GetBool("damage"))
            {
                Accelerate("Direction_J2");
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
                DeAccelerate();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        } else
        {
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
    

        if (ship1)
        {

            if (Input.GetButton("Gravity1") && GetComponent<Rigidbody2D>().gravityScale == 1 && onGround && start && !hasPike1 && hasTurnedAround && !anim.GetBool("damage")) // OR Input.GetButton("Boost1")
            {
                //SoundManagement.Instance.PlayNote("c", "ship1", true);
                onGround = false;
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.3f, -0.5f, 1f);
                if (facingRight)
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, -1f, 1f);
                } 
                else
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, -1f, 1f);
                }
            }

            if (Input.GetButton("Gravity1") && GetComponent<Rigidbody2D>().gravityScale == -1 && onGround && start && !hasPike1 && hasTurnedAround && !anim.GetBool("damage"))
            {
                //SoundManagement.Instance.PlayNote("c","ship1", true);
                onGround = false;
                Debug.Log("normal gravity");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.3f, 0.5f, 1f);
                if (facingRight) {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            
            if ((Input.GetAxis("Pike1") > 0) && !anim.GetBool("damage") && start && onGround) 
            {
                if (!hasPike1) {
                    SoundManagement.Instance.PlayNote("c", "ship2", true);
                }
                //StartCoroutine(Speedboost(0.05f));
                anim.SetBool("defenseON", true);
                //StartCoroutine(SetSpike(0.5f,0.05f, 1));
                MaxSpeed = 0.0f;
                hasPike1 = true;
            }
            else
            {
                anim.SetBool("defenseON", false);
                MaxSpeed = 5;
                hasPike1 = false;
            }
        }


        if (ship2)
        {


            if (Input.GetButton("Gravity2") && GetComponent<Rigidbody2D>().gravityScale == 1 && onGround && start && !hasPike2 && hasTurnedAround && !anim.GetBool("damage"))  
            {
                //SoundManagement.Instance.PlayNote("c","ship2", true);
                onGround = false;
                Debug.Log("normal gravity");
                GetComponent<Rigidbody2D>().gravityScale = -1;
                //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.3f, 0.5f, 1f);
                if (facingRight)
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, 1f, 1f);
                } 
                else
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }

            if (Input.GetButton("Gravity2") && GetComponent<Rigidbody2D>().gravityScale == -1 && onGround && start && !hasPike2 && hasTurnedAround && !anim.GetBool("damage"))
            {
                //SoundManagement.Instance.PlayNote("c","ship2", true);
                onGround = false;
                Debug.Log("flipped gravity");
                GetComponent<Rigidbody2D>().gravityScale = 1;
                //GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.3f, -0.5f, 1f);
                if (facingRight) {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, -1f, 1f);
                }
                else
                {
                    GetComponent<SpriteRenderer>().transform.localScale = new Vector3(-1f, -1f, 1f);
                }
            }


            if ((Input.GetAxis("Pike2") > 0)  && !anim.GetBool("damage") && start && onGround)
            {
                if (!hasPike2)
                {
                    SoundManagement.Instance.PlayNote("c", "ship2", true);
                }
                anim.SetBool("defenseON", true);
                //StartCoroutine(SetSpike(0.5f, 0.05f, 2));
                MaxSpeed = 0.0f;
                hasPike2 = true;
            }
            else
            {
                anim.SetBool("defenseON", false);
                MaxSpeed = 5;
                hasPike2 = false;
            }
        }
    }

    void Accelerate(string s)
    {
        if (Speed < MaxSpeed)
        {
            Speed += 1000.0f; //1.0f * Input.GetAxis(s)
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Top1" && collision.gameObject.GetComponentInParent<Movement>().hasPike1)
        {
            SoundManagement.Instance.PlayLosePointsSound();
            print("ship2 hit pike");
            if (ship2)
            {
                if (hasCollide == false)
                {
                    print("ship2 hit pike");
                    hasCollide = true;
                    scoreP2.GetComponent<Score>().dec(decAmount);
                    StartCoroutine(TopDamage(0.1f, 0.2f, gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Top1")
        {
            SoundManagement.Instance.PlayLosePointsSound();
            print("Top1");
            if (ship2)
            {
                if (hasCollide == false)
                {
                    print("Top1Inner");
                    hasCollide = true;
                    int temp = scoreP1.GetComponent<Score>().score; 
                    if (temp < decAmount)
                    {
                        scoreP2.GetComponent<Score>().inc(temp);
                        scoreP1.GetComponent<Score>().dec(temp);
                    }
                    else
                    {
                        scoreP2.GetComponent<Score>().inc(decAmount);
                        scoreP1.GetComponent<Score>().dec(decAmount);
                    }
                    StartCoroutine(TopDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Top2" && collision.gameObject.GetComponentInParent<Movement>().hasPike2)
        {
            SoundManagement.Instance.PlayLosePointsSound();
            print("ship1 hit pike");
            if (ship1)
            {
                if (hasCollide == false)
                {
                    print("ship1 hit pike");
                    hasCollide = true;
                    scoreP1.GetComponent<Score>().dec(decAmount);
                    StartCoroutine(TopDamage(0.1f, 0.2f, gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "Top2")
        {
            SoundManagement.Instance.PlayLosePointsSound();
            print("Top2");
            if (ship1)
            {
                if (hasCollide == false)
                {
                    print("Top2Inner");
                    hasCollide = true;
                    int temp = (int)scoreP2.GetComponent<Score>().score;
                    if (temp < decAmount)
                    {
                        scoreP1.GetComponent<Score>().inc(temp);
                        scoreP2.GetComponent<Score>().dec(temp);
                    }
                    else
                    {
                        scoreP1.GetComponent<Score>().inc(decAmount);
                        scoreP2.GetComponent<Score>().dec(decAmount);
                    }
                    StartCoroutine(TopDamage(0.1f, 0.2f, collision.gameObject.transform.parent.gameObject, true));
                }
            }
        }
        else if (collision.gameObject.tag == "collectible") //yellow
        {
            if (ship1)
            {
                SoundManagement.Instance.PlayNote("d", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(3, 1);
            }
            else
            {
                SoundManagement.Instance.PlayNote("d", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(3, 1);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "collectibleBlue") 
        {
            if (ship1)
            {
                SoundManagement.Instance.PlayNote("e", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(1, 1);
            }
            else
            {
                SoundManagement.Instance.PlayNote("e", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(1, 1);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "collectibleGreen") 
        {
            if (ship1)
            {
                SoundManagement.Instance.PlayNote("a", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(2, 1);

            }
            else
            {
                SoundManagement.Instance.PlayNote("a", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(2, 1);
            }
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "ColliderLeft")
        {
            newSpawn(false);
            
        }

        else if (collision.gameObject.tag == "ColliderUp" || collision.gameObject.tag == "ColliderDown")
        {
            newSpawn(true);
        }



    }

    public static GameObject GetShip1()
    {
        return GameObject.FindGameObjectWithTag("Ship1");
    }
    public static GameObject GetShip2()
    {
        return GameObject.FindGameObjectWithTag("Ship2");
    }
    void newSpawn(bool dmg)
    {
        Vector3 spawnPos = new Vector3(goRight.transform.position.x-4.0f, goRight.transform.position.y, transform.position.z);
        Vector3 beforeSpawnPos = new Vector3(goRight.transform.position.x-4.0f + 2.0f, goRight.transform.position.y, transform.position.z);
        //Vector3 beforeSpawnPos = new Vector3(goRight.transform.position.x - 4.0f, transform.position.y, transform.position.z);
        RaycastHit2D rayCastHit = Physics2D.Linecast(beforeSpawnPos, spawnPos);

        if (rayCastHit.collider != null)
        {
            if (rayCastHit.distance < 2)
            {
                transform.position = new Vector3(goRight.transform.position.x + 1.0f, goRight.transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(goRight.transform.position.x + 1.0f, goRight.transform.position.y, transform.position.z);
            }
        }
        else
        {
            //transform.position = new Vector3(goRight.transform.position.x - 1.0f, transform.position.y, transform.position.z);
            transform.position = new Vector3(goRight.transform.position.x + 1.0f, goRight.transform.position.y, transform.position.z);
        }
        SpawnPortal(transform.position);

        if (dmg)
        {
            if (ship1)
            {
                scoreP1.GetComponent<Score>().dec(decAmount);
            }
            else
            {
                scoreP2.GetComponent<Score>().dec(decAmount);
            }
            
            StartCoroutine(TopDamage(0.1f, 0.2f, gameObject, true));
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
        //streamParticles.Play();
        MaxSpeed += plusSpeed;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        //streamParticles.Stop();
        MaxSpeed -= plusSpeed;
    }

    IEnumerator Speedboost(float duration)
    {
        //streamParticles.Play();
        MaxSpeed +=  30;
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        //streamParticles.Stop();
        MaxSpeed -= 30;
    }

    IEnumerator LerpOverTime(float duration, Vector3 targetScale)
    {
        Vector3 actualScale = GetComponent<SpriteRenderer>().transform.localScale;             // scale of the object at the begining of the animation
        hasTurnedAround = false;
        //Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);     // scale of the object at the end of the animation
        print(GetComponent<SpriteRenderer>().transform.localScale);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            //print("t: "+t);
            //print("Delta: "+Time.deltaTime);
            //print("localScale: "+GetComponent<SpriteRenderer>().transform.localScale);
            
            if(t > 0.35f && t < 0.65f)
            {
                t = 0.65f; 
            }

            GetComponent<SpriteRenderer>().transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            
            yield return null;
        }


        if(actualScale.x != targetScale.x)
        {
            GetComponent<SpriteRenderer>().transform.localScale = targetScale;
        }

        hasTurnedAround = true;
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

    IEnumerator TopDamage(float duration, float blinkTime, GameObject go, bool minusHP)
    {
        go.transform.position = new Vector3(go.transform.position.x - 1.0f, go.transform.position.y, go.transform.position.z);
        go.GetComponent<Movement2>().anim.SetBool("damage", true);
        
        //go.transform.localScale -= new Vector3(0, 0.3f, 0);
        
        go.GetComponent<Movement>().hasCollide = true;
        go.GetComponent<Movement>().Speed = 0;
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = false;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;

        if (minusHP)
        {
            //go.GetComponent<Movement>().leben--;
        }

        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            //toggle renderer
            //go.GetComponent<Renderer>().enabled = !go.GetComponent<Renderer>().enabled;
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is enabled when we exit
        //go.transform.localScale += new Vector3(0, 0.3f, 0);
        //go.GetComponent<Renderer>().enabled = true;
        go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = true;
        go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = true;
        hasCollide = false;
        go.GetComponent<Movement>().hasCollide = false;
        go.GetComponent<Movement2>().anim.SetBool("damage", false);

    }

    IEnumerator SpawnPortal(Vector3 pos)
    {
        SoundManagement.Instance.PlayPortalSound();
        Instantiate(portal, pos, Quaternion.identity);
        return null;
    }



    /*
IEnumerator BackDamage(float duration, float blinkTime, GameObject go, bool minusHP)
{
    go.transform.localScale -= new Vector3(0.3f, 0, 0);
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
    go.transform.localScale += new Vector3(0.3f, 0, 0);
    go.GetComponent<Renderer>().enabled = true;
    hasCollide = false;
    go.GetComponent<Movement>().hasCollide = false;
    go.transform.GetChild(1).GetComponent<CapsuleCollider2D>().enabled = true;
    go.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = true;
}
*/

    /*
IEnumerator IncreaseValueOverTime()
{

    while (boostAmount < 1f)
    {
        boostAmount += 0.05f;
        yield return new WaitForSeconds(0.5f);
    }
    boostAmount = 1.0f;
}
*/
}
