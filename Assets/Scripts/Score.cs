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

    public int score = 0;
	// Use this for initialization
	void Start () {
        activeObj = new GameObject[field.Length];
        setVal(score);
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
        }
        setVal(score);
    }

    public void dec(int value)
    {
        clear();
        if (score > 0 && score-value >= 0)
        {
            score -= value;
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
            Destroy(activeObj[i]);
        }
    }

    void Print(int activeObj, int score, int field)
    {
        this.activeObj[activeObj] = Instantiate(this.number[score], this.field[field].position, this.field[field].rotation);
        this.activeObj[activeObj].name = this.field[field].name;
        this.activeObj[activeObj].transform.parent = this.field[field];
    }
	
	// Update is called once per frame
	void Update () {
        if (score >= 15)
        {
            if (ship1)
            {
                SceneManager.LoadScene("P1Won");
            }
            else
            {
                SceneManager.LoadScene("P2Won");
            }
            
        }
    }
}
