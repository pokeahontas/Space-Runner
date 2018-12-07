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
    public Sprite[] tiles3 = new Sprite[4];

    public int levelfarbe = 0;
    public int hgBoden = 0;
    public int hgWeit = 0;

    public GameObject[] onlySilTrees;
    public GameObject[] onlyColorTrees;
    public GameObject[] onlySilDesert;
    public GameObject[] onlyColorDesert;

    public GameObject backGroundNeutral1;
    public GameObject backGroundNeutral2;
    public GameObject backGroundForest1;
    public GameObject backGroundForest2;
    public GameObject backGroundDesert1;
    public GameObject backGroundDesert2;

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
            if ((hgWeit <= 2) && !hasChangedFar1 && firstChangeDone) // neutral state
            {
                hasChangedFar1 = true;
                hasChangedFar2 = false;
                hasChangedFar3 = false;
                print("Woooosh2: " + onlySilTrees[0].GetComponent<SpriteRenderer>().color.a +", " + onlySilTrees[1].GetComponent<SpriteRenderer>().color.a );
                
                StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
                ActivateFarBGAndDisableOthers("neutral");
            }
            else if ((hgWeit >= 3 && hgWeit <= 5) && !hasChangedFar2) // blend in sil trees
            {
                if(hasChangedFar3 && !hasChangedFar1 && !hasChangedFar2) // switches down from colored map
                {
                    SetAlphaValue(1.0f, onlySilTrees[0]);
                    SetAlphaValue(1.0f, onlySilTrees[1]);
                    ActivateFarBGAndDisableOthers("neutral");
                } else
                {
                    StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                    StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
                    ActivateFarBGAndDisableOthers("neutral");
                }
                hasChangedFar2 = true;
                hasChangedFar1 = false;
                hasChangedFar3 = false;
                firstChangeDone = true;
                //print("blend in trees");
                
            }
            else if ((hgWeit >= 6 && hgWeit <= 8) && !hasChangedFar3) //switch to color trees and switch to colored BG
            {
                hasChangedFar3 = true;
                hasChangedFar1 = false;
                hasChangedFar2 = false;
                StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
                ActivateFarBGAndDisableOthers("forest");
            }
        }
        else if (levelfarbe == 3 )   //Yellow
        {
            if (hgWeit <= 2 && !hasChangedFar1 && firstChangeDone)
            {
                hasChangedFar1 = true;
                hasChangedFar2 = false;
                hasChangedFar3 = false;

                StartCoroutine(ChangeAlphaValue(onlySilDesert[0].GetComponent<SpriteRenderer>().color.a, onlySilDesert[0]));
                StartCoroutine(ChangeAlphaValue(onlySilDesert[1].GetComponent<SpriteRenderer>().color.a, onlySilDesert[1]));
                ActivateFarBGAndDisableOthers("neutral");
            }
            else if ((hgWeit >= 3 && hgWeit <= 5) && !hasChangedFar2)
            {
                if (hasChangedFar3 && !hasChangedFar1 && !hasChangedFar2) // if switch from colored BG
                {
                    SetAlphaValue(1.0f, onlySilDesert[0]);
                    SetAlphaValue(1.0f, onlySilDesert[1]);
                    ActivateFarBGAndDisableOthers("neutral");
                } else
                {
                    StartCoroutine(ChangeAlphaValue(onlySilDesert[0].GetComponent<SpriteRenderer>().color.a, onlySilDesert[0]));
                    StartCoroutine(ChangeAlphaValue(onlySilDesert[1].GetComponent<SpriteRenderer>().color.a, onlySilDesert[1]));
                    ActivateFarBGAndDisableOthers("neutral");
                }
                hasChangedFar2 = true;
                hasChangedFar1 = false;
                hasChangedFar3 = false;
                firstChangeDone = true;
                //print("blend in trees");
                //StartCoroutine(ChangeAlphaValue(onlySilDesert[0].GetComponent<SpriteRenderer>().color.a, onlySilDesert[0]));
                //StartCoroutine(ChangeAlphaValue(onlySilDesert[1].GetComponent<SpriteRenderer>().color.a, onlySilDesert[1]));
                //ActivateFarBGAndDisableOthers("neutral");
            }
            else if ((hgWeit >= 6 && hgWeit <= 8) && !hasChangedFar3)
            {
                hasChangedFar3 = true;
                hasChangedFar1 = false;
                hasChangedFar2 = false;
                StartCoroutine(ChangeAlphaValue(onlySilDesert[0].GetComponent<SpriteRenderer>().color.a, onlySilDesert[0]));
                StartCoroutine(ChangeAlphaValue(onlySilDesert[1].GetComponent<SpriteRenderer>().color.a, onlySilDesert[1]));
                ActivateFarBGAndDisableOthers("desert");
            }
        }
        else // neutral; levelfarbe == 0
        {
            ActivateFarBGAndDisableOthers("neutral");
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
        


        if (diamondBlue + diamondGreen + diamondYellow == 0)
        {
            levelfarbe = 0;
        } else if(CheckIfTwoDiamondsHaveSameValue())
        {
            levelfarbe = 0;

            int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };

            int max = tempArray.Max();
            int min = tempArray.Min();
            int secondHighest = (from number in tempArray orderby number descending select number).Distinct().Skip(1).First();
            
            //Entfernung von Minimum  
            hgBoden = max - secondHighest;

            //Entfernung von unentschieden
            hgWeit = max - min;

            print("Blue: " + diamondBlue + " Green: " + diamondGreen + " Yellow: " + diamondYellow + ", lvlfarbe=" + levelfarbe + " hgWeit=" + hgWeit + " hgBoden=" + hgBoden);
        }
        else
        {
            int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };
            
            int max = tempArray.Max();
            int min = tempArray.Min();
            int secondHighest = (from number in tempArray orderby number descending select number).Distinct().Skip(1).First();
   
            int p = tempArray.ToList().IndexOf(max);
            levelfarbe = p+1;

            //Entfernung von Minimum  
            hgBoden = max - secondHighest;

            //Entfernung von unentschieden
            hgWeit = max - min;

            print("Blue: " + diamondBlue + " Green: " + diamondGreen + " Yellow: " + diamondYellow + ", lvlfarbe=" + levelfarbe + " hgWeit=" + hgWeit + " hgBoden=" + hgBoden);

        }
    }

    private bool CheckIfTwoDiamondsHaveSameValue()
    {
        bool check;
        int countZeros = 0;
        int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };
        
        foreach(int i in tempArray)
        {
            if(i==0) { countZeros++; }
        }
        if((countZeros<=1) && ((diamondBlue==diamondGreen) || (diamondBlue==diamondYellow) || (diamondYellow==diamondGreen)))
        {
            check = true;
        } 
        else
        {
            check = false;
        }
        return check;
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
    private void SetAlphaValue(float alphaValue, GameObject go)
    {
        Color tmp = go.GetComponent<SpriteRenderer>().color;
        tmp.a = alphaValue;
        go.GetComponent<SpriteRenderer>().color = tmp;
    }

    private void ActivateFarBGAndDisableOthers(string theme) 
    {
        if(theme.Equals("neutral"))
        {
            backGroundNeutral1.SetActive(true);
            backGroundNeutral2.SetActive(true);
            backGroundForest1.SetActive(false);
            backGroundForest2.SetActive(false);
            backGroundDesert1.SetActive(false);
            backGroundDesert2.SetActive(false);
            onlyColorTrees[0].SetActive(false);
            onlyColorTrees[1].SetActive(false);
            onlyColorDesert[0].SetActive(false);
            onlyColorDesert[1].SetActive(false);
            BackgroundSpawner.setBackgroundTheme("neutral");
            //print("ActivateFarBGAndDisableOthers: neutral");
            //TODO rest missing
        } 
        else if(theme.Equals("forest"))
        {
            backGroundNeutral1.SetActive(false);
            backGroundNeutral2.SetActive(false);
            backGroundForest1.SetActive(true);
            backGroundForest2.SetActive(true);
            backGroundDesert1.SetActive(false);
            backGroundDesert2.SetActive(false);
            onlyColorTrees[0].SetActive(true);
            onlyColorTrees[1].SetActive(true);
            onlyColorDesert[0].SetActive(false);
            onlyColorDesert[1].SetActive(false);
            BackgroundSpawner.setBackgroundTheme("forest");
        }
        else if (theme.Equals("desert"))
        {
            backGroundNeutral1.SetActive(false);
            backGroundNeutral2.SetActive(false);
            backGroundForest1.SetActive(false);
            backGroundForest2.SetActive(false);
            backGroundDesert1.SetActive(true);
            backGroundDesert2.SetActive(true);
            onlyColorTrees[0].SetActive(false);
            onlyColorTrees[1].SetActive(false);
            onlyColorDesert[0].SetActive(true);
            onlyColorDesert[1].SetActive(true);
            BackgroundSpawner.setBackgroundTheme("desert");
        }
        else if (theme.Equals("snow"))
        {
            //TODO
            BackgroundSpawner.setBackgroundTheme("snow");
        }
    }
}
