using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManagement : MonoBehaviour {

    private static LevelManagement _instance;

    public static LevelManagement Instance { get { return _instance; } }

    int diamondBlue = 0;
    int diamondGreen = 0;
    int diamondYellow = 0;

    public Sprite[] tiles = new Sprite[4];
    public Sprite[] tiles2 = new Sprite[4];

    public int levelfarbe = 0;
    public int hgBoden = 0;
    public int hgWeit = 0;

    public GameObject[] onlySilTrees;
    public bool hasChangedFar1;
    public bool hasChangedFar2;
    public bool hasChangedFar3;
    public bool firstChangeDone;

    private void Awake()
    {
        hasChangedFar1 = false;
        hasChangedFar2 = false;
        hasChangedFar3 = false;
        firstChangeDone = false;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if (levelfarbe == 1) {  //Blue
            if (hgWeit <= 2)
            {

            } else if (hgWeit >= 3 && hgWeit <= 5)
            {
                
            } else if (hgWeit >= 6 && hgWeit <= 8)
            {

            }
        } else if (levelfarbe == 2) //Green
        {
            if ((hgWeit <= 2) && !hasChangedFar1 && firstChangeDone)
            {
                hasChangedFar1 = true;
                hasChangedFar2 = false;
                hasChangedFar3 = false;
                print("Woooosh2: " + onlySilTrees[0].GetComponent<SpriteRenderer>().color.a +", " + onlySilTrees[1].GetComponent<SpriteRenderer>().color.a );
                if (onlySilTrees[0].GetComponent<SpriteRenderer>().color.a > 0.1f) {
                    print("Woooosh1");
                    StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                    StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
                }
            }
            else if ((hgWeit >= 3 && hgWeit <= 5) && !hasChangedFar2)
            {
                hasChangedFar2 = true;
                hasChangedFar1 = false;
                hasChangedFar3 = false;
                firstChangeDone = true;
                //print("blend in trees");
                StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
            }
            else if ((hgWeit >= 6 && hgWeit <= 8) && !hasChangedFar3)
            {
                hasChangedFar3 = true;
                hasChangedFar1 = false;
                hasChangedFar2 = false;
            }
        }
        else if (levelfarbe == 3)   //Yellow
        {
            if (hgWeit <= 2)
            {

            }
            else if (hgWeit >= 3 && hgWeit <= 5)
            {

            }
            else if (hgWeit >= 6 && hgWeit <= 8)
            {

            }
        }
    }

    public void updateDiamond(int color, int value)
    {
        if (color == 1)
        {
            diamondBlue += value;
        }
        else if (color == 2)
        {
            diamondGreen += value;
        }
        else if (color == 3)
        {
            diamondYellow += value;
        }
        print("Blue: " + diamondBlue + " Green: " + diamondGreen + " Yellow: " + diamondYellow);


        if (diamondBlue + diamondGreen + diamondYellow == 0)
        {
            levelfarbe = 0;
        }
        else
        {
            int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };
            
            int max = tempArray.Max();
            int min = tempArray.Min();
            int secondHighest = (from number in tempArray orderby number descending select number).Distinct().Skip(1).First();
   
            int p = tempArray.ToList().IndexOf(max);
            levelfarbe = p+1;

            //Entfernung von Minimum ; INFO: WAR VERWECHSELT    
            hgWeit = max - secondHighest;

            //Entfernung von unentschieden
            hgBoden = max - min;

        }
    }

    IEnumerator ChangeAlphaValue(float alphaValue, GameObject go)
    {
        if(alphaValue > 0.1f)
        {
            while (alphaValue > 0.0f)
            {
                alphaValue -= 0.1f;
                Color tmp = go.GetComponent<SpriteRenderer>().color;
                tmp.a = alphaValue;
                yield return new WaitForSeconds(0.1f);
                go.GetComponent<SpriteRenderer>().color = tmp;
            }
        } else
        {
            while (alphaValue < 1.0f)
            {
                alphaValue += 0.1f;
                Color tmp = go.GetComponent<SpriteRenderer>().color;
                tmp.a = alphaValue;
                yield return new WaitForSeconds(0.1f);
                go.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }
}
