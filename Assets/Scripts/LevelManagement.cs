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

    public Sprite[] BgBoden1 = new Sprite[4];
    public Sprite[] BgBoden2 = new Sprite[4];
    public Sprite[] BgBoden3 = new Sprite[4];
    public Sprite[] BgBoden4 = new Sprite[4];
    public Sprite[] BgBoden5 = new Sprite[4];

    public int levelfarbe = 0;
    public int hgBoden = 0;
    public int hgWeit = 0;

    public GameObject[] onlySilTrees;
    public GameObject[] onlyColorTrees;
    public GameObject[] onlySilDesert;
    public GameObject[] onlyColorDesert;
    public GameObject[] onlyColorSnowTrees;

    public GameObject backGroundNeutral1;
    public GameObject backGroundNeutral2;
    public GameObject backGroundForest1;
    public GameObject backGroundForest2;
    public GameObject backGroundDesert1;
    public GameObject backGroundDesert2;
    public GameObject backGroundSnow1;
    public GameObject backGroundSnow2;

    public bool hasChangedFar1;
    public bool hasChangedFar2;
    public bool hasChangedFar3;
    public bool firstChangeDone;

    GameObject boden;

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
            //print(hasChangedFar1 + "," + firstChangeDone);
            if ((hgWeit <= 2) && !hasChangedFar1 && firstChangeDone) // neutral state
            {
                hasChangedFar1 = true;
                hasChangedFar2 = false;
                hasChangedFar3 = false;

                StartCoroutine(ChangeAlphaValue(onlySilTrees[0].GetComponent<SpriteRenderer>().color.a, onlySilTrees[0]));
                StartCoroutine(ChangeAlphaValue(onlySilTrees[1].GetComponent<SpriteRenderer>().color.a, onlySilTrees[1]));
                ActivateFarBGAndDisableOthers("neutral");
            }
            else if ((hgWeit >= 3 && hgWeit <= 5) && !hasChangedFar2) // blend in sil trees
            {
                if (hasChangedFar3 && !hasChangedFar1 && !hasChangedFar2) // switches down from colored map
                {
                    SetAlphaValue(1.0f, onlySilTrees[0]);
                    SetAlphaValue(1.0f, onlySilTrees[1]);
                    ActivateFarBGAndDisableOthers("neutral");
                }
                else
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
                ActivateFarBGAndDisableOthers("snow");
            }
        } else if (levelfarbe == 2) //Green
        {
            //print(hasChangedFar1 + "," + firstChangeDone);
            if ((hgWeit <= 2) && !hasChangedFar1 && firstChangeDone) // neutral state
            {
                hasChangedFar1 = true;
                hasChangedFar2 = false;
                hasChangedFar3 = false;
                
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
        boden = GameObject.Find("BgBodenElemente");

        if (hgBoden > 1)
        {
            boden.transform.GetChild(0).gameObject.SetActive(true);
            boden.transform.GetChild(1).gameObject.SetActive(true);
            if (hgBoden > 2)
            {
                boden.transform.GetChild(2).gameObject.SetActive(true);
                boden.transform.GetChild(3).gameObject.SetActive(true);
                if (hgBoden > 3)
                {
                    boden.transform.GetChild(4).gameObject.SetActive(true);
                    boden.transform.GetChild(5).gameObject.SetActive(true);
                }
                else
                {
                    boden.transform.GetChild(4).gameObject.SetActive(false);
                    boden.transform.GetChild(5).gameObject.SetActive(false);
                }
            }
            else
            {
                boden.transform.GetChild(2).gameObject.SetActive(false);
                boden.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
        else
        {
            boden.transform.GetChild(0).gameObject.SetActive(false);
            boden.transform.GetChild(1).gameObject.SetActive(false);
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

        int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };

        int max = tempArray.Max();
        int min = tempArray.Min();
        int secondHighest = (from number in tempArray orderby number descending select number).Distinct().Skip(1).First();
        int secondLargest = tempArray[tempArray.Length - 2];

        //Entfernung von Minimum  
        hgBoden = max - secondLargest;

        //Entfernung von unentschieden
        hgWeit = max - min;

        if ((diamondBlue + diamondGreen + diamondYellow == 0) || (max == secondHighest) || (max == secondHighest && max == min))
        {
            levelfarbe = 0;
            print("Blue: " + diamondBlue + " Green: " + diamondGreen + " Yellow: " + diamondYellow + ", lvlfarbe=" + levelfarbe + " hgWeit=" + hgWeit + " hgBoden=" + hgBoden);
        } 
        else
        {
            int p = tempArray.ToList().IndexOf(max);
            levelfarbe = p+1;

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
            backGroundSnow1.SetActive(false);
            backGroundSnow2.SetActive(false);
            onlyColorTrees[0].SetActive(false);
            onlyColorTrees[1].SetActive(false);
            onlyColorDesert[0].SetActive(false);
            onlyColorDesert[1].SetActive(false);
            onlyColorSnowTrees[0].SetActive(false);
            onlyColorSnowTrees[1].SetActive(false);
            BackgroundSpawner.setBackgroundTheme("neutral");
        } 
        else if(theme.Equals("forest"))
        {
            backGroundNeutral1.SetActive(false);
            backGroundNeutral2.SetActive(false);
            backGroundForest1.SetActive(true);
            backGroundForest2.SetActive(true);
            backGroundDesert1.SetActive(false);
            backGroundDesert2.SetActive(false);
            backGroundSnow1.SetActive(false);
            backGroundSnow2.SetActive(false);
            onlyColorTrees[0].SetActive(true);
            onlyColorTrees[1].SetActive(true);
            onlyColorDesert[0].SetActive(false);
            onlyColorDesert[1].SetActive(false);
            onlyColorSnowTrees[0].SetActive(false);
            onlyColorSnowTrees[1].SetActive(false);
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
            backGroundSnow1.SetActive(false);
            backGroundSnow2.SetActive(false);
            onlyColorTrees[0].SetActive(false);
            onlyColorTrees[1].SetActive(false);
            onlyColorDesert[0].SetActive(true);
            onlyColorDesert[1].SetActive(true);
            onlyColorSnowTrees[0].SetActive(false);
            onlyColorSnowTrees[1].SetActive(false);
            BackgroundSpawner.setBackgroundTheme("desert");
        }
        else if (theme.Equals("snow"))
        {
            backGroundNeutral1.SetActive(false);
            backGroundNeutral2.SetActive(false);
            backGroundForest1.SetActive(false);
            backGroundForest2.SetActive(false);
            backGroundDesert1.SetActive(false);
            backGroundDesert2.SetActive(false);
            backGroundSnow1.SetActive(true);
            backGroundSnow2.SetActive(true);
            onlyColorTrees[0].SetActive(false);
            onlyColorTrees[1].SetActive(false);
            onlyColorDesert[0].SetActive(true);
            onlyColorDesert[1].SetActive(true);
            onlyColorSnowTrees[0].SetActive(true);
            onlyColorSnowTrees[1].SetActive(true);
            BackgroundSpawner.setBackgroundTheme("snow");
        }
    }
}
