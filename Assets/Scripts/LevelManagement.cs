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

    //child objects of neutral BG
    public GameObject[] onlySilTrees;
    public GameObject[] onlySilDesert;

    //child objects of themed BG
    public GameObject[] silForest;
    public GameObject[] silDesert;
    public GameObject[] silSnow;

    public GameObject[] backGroundNeutral;
    public GameObject[] backGroundForest;
    public GameObject[] backGroundDesert;
    public GameObject[] backGroundSnow;

    public GameObject[] bgColorForestFar1;
    public GameObject[] bgColorForestFar2;
    public GameObject[] bgColorDesertFar1;
    public GameObject[] bgColorDesertFar2;
    public GameObject[] bgColorSnowFar1;
    public GameObject[] bgColorSnowFar2;

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
        if ((hgWeit <= 2) || (levelfarbe == 0))
        {
            // deactivate all silhouettes, colored elements and activate neutral background(if its not already activated)
            DeactivateLayer("all");
            ActivateBGDeactivateOthers("neutral");

        }
        else
        {
            if (levelfarbe == 1)
            {  //Blue
                if (hgWeit >= 3 && hgWeit <= 4)
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate snowtree silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("snow",false);
                    DeactivateLayer("color");

                }
                else if (hgWeit == 5)
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);

                }
                else if (hgWeit == 6)
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);
                }
                else if (hgWeit == 7)
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);
                }
                else if (hgWeit >= 8)
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "snow");
                    DeactivateLayer("sil");
                }
            }
            else if (levelfarbe == 2) //Green
            {
                if (hgWeit >= 3 && hgWeit <= 4)
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate snowtree silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("forest",false);
                    DeactivateLayer("color");

                }
                else if (hgWeit == 5)
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);

                }
                else if (hgWeit == 6)
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);
                }
                else if (hgWeit == 7)
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);
                }
                else if (hgWeit >= 8)
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "forest");
                    DeactivateLayer("sil");
                }
            }
            else if (levelfarbe == 3)   //Yellow
            {
                if (hgWeit >= 3 && hgWeit <= 4)
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate snowtree silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("desert",false);
                    DeactivateLayer("color");

                }
                else if (hgWeit == 5)
                {
                    ActivateBGDeactivateOthers("desert");
                    // activate colored snow tree 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);

                }
                else if (hgWeit == 6)
                {
                    ActivateBGDeactivateOthers("desert");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);
                }
                else if (hgWeit == 7)
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("desert");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);
                }
                else if (hgWeit >= 8)
                {
                    ActivateBGDeactivateOthers("deserts");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "desert");
                    DeactivateLayer("sil");
                }
            }
        }



    }

    private void ActivateBGDeactivateOthers(string theme)
    {
        if (theme.Equals("neutral"))
        {
            SetActivationOfGoInArray(ref backGroundNeutral, true);
            SetActivationOfGoInArray(ref backGroundSnow, false);
            SetActivationOfGoInArray(ref backGroundForest, false);
            SetActivationOfGoInArray(ref backGroundDesert, false);
        }
        else if (theme.Equals("snow"))
        {
            SetActivationOfGoInArray(ref backGroundNeutral, false);
            SetActivationOfGoInArray(ref backGroundSnow, true);
            SetActivationOfGoInArray(ref backGroundForest, false);
            SetActivationOfGoInArray(ref backGroundDesert, false);
        }
        else if (theme.Equals("forest"))
        {
            SetActivationOfGoInArray(ref backGroundNeutral, false);
            SetActivationOfGoInArray(ref backGroundSnow, false);
            SetActivationOfGoInArray(ref backGroundForest, true);
            SetActivationOfGoInArray(ref backGroundDesert, false);
        }
        else if (theme.Equals("desert"))
        {
            SetActivationOfGoInArray(ref backGroundNeutral, false);
            SetActivationOfGoInArray(ref backGroundSnow, false);
            SetActivationOfGoInArray(ref backGroundForest, false);
            SetActivationOfGoInArray(ref backGroundDesert, true);
        }
        BackgroundSpawner.setBackgroundTheme(theme);
    }

    private void ActivateSilhouetteAndDeactivateOthers(string theme, bool isColoredBG)
    {
        if (!isColoredBG) {
            if (theme.Equals("snow"))
            {
                SetActivationOfGoInArray(ref onlySilDesert, false);
                SetActivationOfGoInArray(ref onlySilTrees, true);
            }
            else if (theme.Equals("forest"))
            {
                SetActivationOfGoInArray(ref onlySilDesert, false);
                SetActivationOfGoInArray(ref onlySilTrees, true);
            }
            else if (theme.Equals("desert"))
            {
                SetActivationOfGoInArray(ref onlySilDesert, true);
                SetActivationOfGoInArray(ref onlySilTrees, false);
            }
        } 
        else
        {
            if (theme.Equals("snow"))
            {
                SetActivationOfGoInArray(ref silForest, false);
                SetActivationOfGoInArray(ref silDesert, false);
                SetActivationOfGoInArray(ref silSnow, true);
            }
            else if (theme.Equals("forest"))
            {
                SetActivationOfGoInArray(ref silForest, true);
                SetActivationOfGoInArray(ref silDesert, false);
                SetActivationOfGoInArray(ref silSnow, false);
            }
            else if (theme.Equals("desert"))
            {
                SetActivationOfGoInArray(ref silForest, false);
                SetActivationOfGoInArray(ref silDesert, true);
                SetActivationOfGoInArray(ref silSnow, false);
            }
        }
    }

    private void SetActivationOfGoInArray(ref GameObject[] bgArray, bool which)
    {
        foreach (GameObject go in bgArray)
        {
            if (go) {
                go.SetActive(which);
            }
        }
    }
    private void SetActivationOfGoInArrayOneDifferent(ref GameObject[] bgArray, bool which, int i)
    {
        int count = 0;
        foreach (GameObject go in bgArray)
        {
            //Set every element state to which, el[i] to !which
            if (count == i)
            {
                if(go)
                go.SetActive(which);
            }
            else
            {
                if(go)
                go.SetActive(!which);
            }
            count++;
        }
    }

    private void ActivateColoredElementsDeactivateOthers(int level, string theme)
    {
        if (theme.Equals("snow"))
        {
            if (level == 0)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 0);
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 0);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 1)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 1);
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 1);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 2)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 2);
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 2);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 3)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 3);
                SetActivationOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 3);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
            }
        }
        else if (theme.Equals("forest"))
        {
            if (level == 0)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 0);
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 0);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 1)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 1);
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 1);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 2)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 2);
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 2);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 3)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 3);
                SetActivationOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 3);

                SetActivationOfGoInArray(ref bgColorDesertFar1, false);
                SetActivationOfGoInArray(ref bgColorDesertFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
        }
        else if (theme.Equals("desert"))
        {
            if (level == 0)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 0);
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 0);

                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 1)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 1);
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 1);

                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 2)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 2);
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 2);

                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 3)
            {
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 3);
                SetActivationOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 3);

                SetActivationOfGoInArray(ref bgColorForestFar1, false);
                SetActivationOfGoInArray(ref bgColorForestFar2, false);
                SetActivationOfGoInArray(ref bgColorSnowFar1, false);
                SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            }
        }
    }

    private void DeactivateLayer(string level)
    {
        if (level.Equals("all"))
        {
            SetActivationOfGoInArray(ref bgColorSnowFar1, false);
            SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            SetActivationOfGoInArray(ref bgColorDesertFar1, false);
            SetActivationOfGoInArray(ref bgColorDesertFar2, false);
            SetActivationOfGoInArray(ref bgColorForestFar1, false);
            SetActivationOfGoInArray(ref bgColorForestFar2, false);
            SetActivationOfGoInArray(ref onlySilDesert, false);
            SetActivationOfGoInArray(ref onlySilTrees, false);
        }
        else if (level.Equals("sil"))
        {
            SetActivationOfGoInArray(ref onlySilDesert, false);
            SetActivationOfGoInArray(ref onlySilTrees, false);
        }
        else if (level.Equals("color"))
        {
            SetActivationOfGoInArray(ref bgColorSnowFar1, false);
            SetActivationOfGoInArray(ref bgColorSnowFar2, false);
            SetActivationOfGoInArray(ref bgColorDesertFar1, false);
            SetActivationOfGoInArray(ref bgColorDesertFar2, false);
            SetActivationOfGoInArray(ref bgColorForestFar1, false);
            SetActivationOfGoInArray(ref bgColorForestFar2, false);
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
        int[] ordered = (from number in tempArray orderby number descending select number).ToArray();
        int secondHighest = ordered[1];
        print("second "+ secondHighest);


        //Entfernung von Minimum  
        hgBoden = max - secondHighest;

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

    IEnumerator ChangeAlphaValue(float alphaValue, GameObject go) // not used
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
    private void SetAlphaValue(float alphaValue, GameObject go) // not used
    {
        Color tmp = go.GetComponent<SpriteRenderer>().color;
        tmp.a = alphaValue;
        go.GetComponent<SpriteRenderer>().color = tmp;
    }

}
