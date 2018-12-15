using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour {

    public GameObject[] number;
    public Transform[] field;
    GameObject[] activeObj;

    public bool ship1;
    public bool ship2;

    private bool endMelodyHasPlayed;
    private Vector3 posAboveHead;
    public int score = 0;

    public GameObject aboveHead;
    public GameObject numberOne;
    public GameObject numberTwo;
    public GameObject numberThree;
    public GameObject numberFour;
    public GameObject numberFive;
    public GameObject plusSign;
    public GameObject minusSign;

    // Use this for initialization
    void Start () {
        activeObj = new GameObject[field.Length];
        setVal(score);
        endMelodyHasPlayed = false;
    }

    void setVal(int score)
    {
        int Convert = 1;
        for (int i =0;i<field.Length;i++)
        {
            int scoreConvert = (score / Convert) % 10;
            Print(i, scoreConvert, i);
            Convert *= 10;
        }
    }

    public void inc(int value)
    {
        clear();
        if (score<99)
        {
            score += value;
            StartCoroutine(ShowDiamondsAbovePlayer(0.2f,value, true));
        }
        setVal(score);
    }

    public void dec(int value)
    {
        clear();
        if (score > 0 && (score-value) >= 0)
        {
            score -= value;
            StartCoroutine(ShowDiamondsAbovePlayer(0.2f, value, false));
        }
        else
        {
            score = 0;
        }
        setVal(score);
    }

    public int getScore()
    {
        return score;
    }

    void clear()
    {
        for (int i=0;i<field.Length;i++)
        {
           // Destroy(activeObj[i]);
        }
    }

    void Print(int activeObj, int score, int field)
    {
       // this.activeObj[activeObj] = Instantiate(this.number[score], this.field[field].position, this.field[field].rotation);
       // this.activeObj[activeObj].name = this.field[field].name;
       // this.activeObj[activeObj].transform.parent = this.field[field];
    }

    IEnumerator ShowDiamondsAbovePlayer(float duration, int value, bool positiveNumber)
    {
        if (positiveNumber)
        {
            plusSign.SetActive(true);
        }
        else
        {
            minusSign.SetActive(true);
        }
        if (value == 1)
        {
            numberOne.SetActive(true);

            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

            numberOne.SetActive(false);
        }
        else if (value == 2)
        {
            numberTwo.SetActive(true);

            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

            numberTwo.SetActive(false);
        }
        else if (value == 3)
        {
            numberThree.SetActive(true);

            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

            numberThree.SetActive(false);
        }
        else if (value == 4)
        {
            numberFour.SetActive(true);

            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

            numberFour.SetActive(false);
        }
        else if (value == 5)
        {
            numberFive.SetActive(true);

            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }

            numberFive.SetActive(false);
        }

        plusSign.SetActive(false);
        minusSign.SetActive(false);
    }

    // Update is called once per frame

    void Update () {

        if(ship1)
        {
            posAboveHead = Movement.GetShip1().transform.position;
            if (Movement.GetShip1().GetComponent<Rigidbody2D>().gravityScale == 1) {
                posAboveHead.y += 0.3f;
            } else
            {
                posAboveHead.y -= 2.3f;
            }
            aboveHead.transform.position = posAboveHead;
        }
        if(ship2)
        {
            posAboveHead = Movement.GetShip2().transform.position;
            if (Movement.GetShip2().GetComponent<Rigidbody2D>().gravityScale == 1)
            {
                posAboveHead.y += 0.3f;
            } else
            {
                posAboveHead.y -= 2.3f;
            }
            aboveHead.transform.position = posAboveHead;
        }
        
        if (score >= 15 && !endMelodyHasPlayed)
        {
            if (ship1)
            {
                SoundManagement.Instance.PlayEndMelody("ship1");
                endMelodyHasPlayed = true;
                SceneManager.LoadScene("P1Won");
            }
            else
            {
                SoundManagement.Instance.PlayEndMelody("ship2");
                endMelodyHasPlayed = true;
                SceneManager.LoadScene("P2Won");
            }
            
        }
    }
}
