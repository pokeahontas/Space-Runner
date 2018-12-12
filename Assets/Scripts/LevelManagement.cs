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

    public bool isInNeutralState;
    public bool isInColor1_Stage1;
    public bool isInColor1_Stage2;
    public bool isInColor1_Stage3;
    public bool isInColor1_Stage4;
    public bool isInColor1_Stage5;

    public bool isInColor2_Stage1;
    public bool isInColor2_Stage2;
    public bool isInColor2_Stage3;
    public bool isInColor2_Stage4;
    public bool isInColor2_Stage5;

    public bool isInColor3_Stage1;
    public bool isInColor3_Stage2;
    public bool isInColor3_Stage3;
    public bool isInColor3_Stage4;
    public bool isInColor3_Stage5;

    private void Awake()
    {
        isInNeutralState = false;
        isInColor1_Stage1 = false;
        isInColor1_Stage2 = false;
        isInColor1_Stage3 = false;
        isInColor1_Stage4 = false;
        isInColor1_Stage5 = false;

        isInColor2_Stage1 = false;
        isInColor2_Stage2 = false;
        isInColor2_Stage3 = false;
        isInColor2_Stage4 = false;
        isInColor2_Stage5 = false;

        isInColor3_Stage1 = false;
        isInColor3_Stage2 = false;
        isInColor3_Stage3 = false;
        isInColor3_Stage4 = false;
        isInColor3_Stage5 = false;

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
        if ((hgWeit <= 2 || levelfarbe == 0) && !isInNeutralState)
        {
            //Debug.Log("TESTING1");
            isInNeutralState = true;
            isInColor1_Stage1 = false;
            isInColor1_Stage2 = false;
            isInColor1_Stage3 = false;
            isInColor1_Stage4 = false;
            isInColor1_Stage5 = false;

            isInColor2_Stage1 = false;
            isInColor2_Stage2 = false;
            isInColor2_Stage3 = false;
            isInColor2_Stage4 = false;
            isInColor2_Stage5 = false;

            isInColor3_Stage1 = false;
            isInColor3_Stage2 = false;
            isInColor3_Stage3 = false;
            isInColor3_Stage4 = false;
            isInColor3_Stage5 = false;
            // deactivate all silhouettes, colored elements and activate neutral background(if its not already activated)
            DeactivateLayer("all");
            ActivateBGDeactivateOthers("neutral");
            
        }
        else
        {
            if (levelfarbe == 1)
            {  //Blue
                if ((hgWeit >= 3 && hgWeit <= 4) && !isInColor1_Stage1) //Color 1 Stage 1
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate snowtree silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("snow",false);
                    DeactivateLayer("color");

                    isInNeutralState = false;
                    isInColor1_Stage1 = true;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;

                }
                else if (hgWeit == 5 && !isInColor1_Stage2)           //Color 1 Stage 2
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = true;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit == 6 && !isInColor1_Stage3)           //Color 1 Stage 3
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = true;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit == 7 && !isInColor1_Stage4)           //Color 1 Stage 4
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "snow");
                    ActivateSilhouetteAndDeactivateOthers("snow",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = true;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit >= 8 && !isInColor1_Stage5)           //Color 1 Stage 5
                {
                    ActivateBGDeactivateOthers("snow");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "snow");
                    DeactivateLayer("sil");

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = true;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
            }
            else if (levelfarbe == 2) //Green
            {
                if ((hgWeit >= 3 && hgWeit <= 4) && !isInColor2_Stage1) // Color 2 Stage 1
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate snowtree silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("forest",false);
                    DeactivateLayer("color");

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = true;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;

                }
                else if (hgWeit == 5 && !isInColor2_Stage2) // Color 2 Stage 2
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = true;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;

                }
                else if (hgWeit == 6 && !isInColor2_Stage3) // Color 2 Stage 3
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = true;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit == 7 && !isInColor2_Stage4) // Color 2 Stage 4
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "forest");
                    ActivateSilhouetteAndDeactivateOthers("forest",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = true;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit >= 8 && !isInColor2_Stage5) // Color 2 Stage 5
                {
                    ActivateBGDeactivateOthers("forest");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "forest");
                    DeactivateLayer("sil");

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = true;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
            }
            else if (levelfarbe == 3)   //Yellow
            {
                if ((hgWeit >= 3 && hgWeit <= 4) && !isInColor3_Stage1) // Color 3 Stage 1
                {
                    ActivateBGDeactivateOthers("neutral");
                    // activate desert silhouettes and deactivate every other silhouette 
                    ActivateSilhouetteAndDeactivateOthers("desert",false);
                    DeactivateLayer("color");

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = true;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;

                }
                else if (hgWeit == 5 && !isInColor3_Stage2) // Color 3 Stage 2
                {
                    ActivateBGDeactivateOthers("desert");
                    // activate colored cactus 1 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(0, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = true;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;

                }
                else if (hgWeit == 6 && !isInColor3_Stage3) // Color 3 Stage 3
                {
                    ActivateBGDeactivateOthers("desert");
                    // activate colored snow tree 2 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(1, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = true;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit == 7 && !isInColor3_Stage4) // Color 3 Stage 4
                {
                    // activate snow background and deactivate all others
                    ActivateBGDeactivateOthers("desert");
                    // activate colored snow tree 3 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(2, "desert");
                    ActivateSilhouetteAndDeactivateOthers("desert",true);

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = true;
                    isInColor3_Stage5 = false;
                }
                else if (hgWeit >= 8 && !isInColor3_Stage5) // Color 3 Stage 5
                {
                    ActivateBGDeactivateOthers("deserts");
                    // activate colored snow tree 4 and deactivate every other colored 
                    ActivateColoredElementsDeactivateOthers(3, "desert");
                    DeactivateLayer("sil");

                    isInNeutralState = false;
                    isInColor1_Stage1 = false;
                    isInColor1_Stage2 = false;
                    isInColor1_Stage3 = false;
                    isInColor1_Stage4 = false;
                    isInColor1_Stage5 = false;

                    isInColor2_Stage1 = false;
                    isInColor2_Stage2 = false;
                    isInColor2_Stage3 = false;
                    isInColor2_Stage4 = false;
                    isInColor2_Stage5 = false;

                    isInColor3_Stage1 = false;
                    isInColor3_Stage2 = false;
                    isInColor3_Stage3 = false;
                    isInColor3_Stage4 = false;
                    isInColor3_Stage5 = true;
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
                if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f) {
                    StartCoroutineOfGoInArray(ref onlySilDesert, false);
                }
                if (onlySilTrees[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref onlySilTrees, true);
                }
            }
            else if (theme.Equals("forest"))
            {
                if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref onlySilDesert, false);
                }
                if (onlySilTrees[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref onlySilTrees, true);
                }
            }
            else if (theme.Equals("desert"))
            {
                if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref onlySilDesert, true);
                }
                if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref onlySilTrees, false);
                }
            }
        } 
        else
        {
            if (theme.Equals("snow"))
            {
                if (silForest[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silForest, false);
                }
                if (silDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silDesert, false);
                }
                if (silSnow[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silSnow, true);
                }
            }
            else if (theme.Equals("forest"))
            {
                if (silForest[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silForest, true);
                }
                if (silDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silDesert, false);
                }
                if (silSnow[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silSnow, false);
                }
            }
            else if (theme.Equals("desert"))
            {
                if (silDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silForest, false);
                }
                if (silDesert[0].GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silDesert, true);
                }
                if (silSnow[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    StartCoroutineOfGoInArray(ref silSnow, false);
                }
            }
        }
    }

    private void StartCoroutineOfGoInArray(ref GameObject[] bgArray, bool which)
    {
        foreach (GameObject go in bgArray)
        {
            if (go) { //&& go.GetComponent<SpriteRenderer>().color.a > 0.5f
                //Debug.Log("TESTING1");
                //go.SetActive(which);
                StartCoroutine(ChangeAlphaValue(go.GetComponent<SpriteRenderer>().color.a, new Ref<GameObject>(go)));
            }
        }
    }
    private void SetActivationOfGoInArray(ref GameObject[] bgArray, bool which)
    {
        foreach (GameObject go in bgArray)
        {
            if (go)
            {
                //Debug.Log("TESTING1");
                go.SetActive(which);
            }
        }
    }
    private void StartCoroutineOfGoInArrayOneDifferent(ref GameObject[] bgArray, bool which, int i)
    {
        int count = 0;
        foreach (GameObject go in bgArray)
        {
            //Set every element state to which, el[i] to !which
            if (count == i)
            {
                if (go && go.GetComponent<SpriteRenderer>().color.a < 0.5f)
                {
                    //go.SetActive(which);
                    StartCoroutine(ChangeAlphaValue(go.GetComponent<SpriteRenderer>().color.a, new Ref<GameObject>(go)));
                }
            }
            else
            {
                if (go && go.GetComponent<SpriteRenderer>().color.a > 0.5f)
                {
                    //go.SetActive(!which);
                    StartCoroutine(ChangeAlphaValue(go.GetComponent<SpriteRenderer>().color.a, new Ref<GameObject>(go)));
                }
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
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 0);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 0);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 1)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 1);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 1);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 2)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 2);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 2);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
            }
            else if (level == 3)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar1, true, 3);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorSnowFar2, true, 3);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
            }
        }
        else if (theme.Equals("forest"))
        {
            if (level == 0)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 0);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 0);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 1)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 1);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 1);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 2)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 2);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 2);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 3)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar1, true, 3);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorForestFar2, true, 3);

                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
        }
        else if (theme.Equals("desert"))
        {
            if (level == 0)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 0);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 0);

                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 1)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 1);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 1);

                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 2)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 2);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 2);

                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            else if (level == 3)
            {
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar1, true, 3);
                StartCoroutineOfGoInArrayOneDifferent(ref bgColorDesertFar2, true, 3);

                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
        }
    }

    private void DeactivateLayer(string level)
    {
        if (level.Equals("all"))
        {
            if (bgColorSnowFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f) {
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            if (bgColorDesertFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
            }
            if (bgColorForestFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
            }
            if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref onlySilDesert, false);
            }
            if (onlySilTrees[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref onlySilTrees, false);
            }
        }
        else if (level.Equals("sil"))
        {
            if (onlySilDesert[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref onlySilDesert, false);
            }
            if (onlySilTrees[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref onlySilTrees, false);
            }
        }
        else if (level.Equals("color"))
        {
            if (bgColorSnowFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref bgColorSnowFar1, false);
                StartCoroutineOfGoInArray(ref bgColorSnowFar2, false);
            }
            if (bgColorDesertFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref bgColorDesertFar1, false);
                StartCoroutineOfGoInArray(ref bgColorDesertFar2, false);
            }
            if (bgColorForestFar1[0].GetComponent<SpriteRenderer>().color.a > 0.5f)
            {
                StartCoroutineOfGoInArray(ref bgColorForestFar1, false);
                StartCoroutineOfGoInArray(ref bgColorForestFar2, false);
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

    IEnumerator ChangeAlphaValue(float alphaValue, Ref<GameObject> go) // not used
    {
        if(alphaValue > 0.1f)
        {
            while (alphaValue > 0.0f)
            {
                alphaValue -= 0.1f;
                Color tmp = go.Value.GetComponent<SpriteRenderer>().color;
                tmp.a = alphaValue;
                yield return new WaitForSeconds(0.1f);
                go.Value.GetComponent<SpriteRenderer>().color = tmp;
            }
        } else
        {
            while (alphaValue < 1.0f)
            {
                alphaValue += 0.1f;
                Color tmp = go.Value.GetComponent<SpriteRenderer>().color;
                tmp.a = alphaValue;
                yield return new WaitForSeconds(0.1f);
                go.Value.GetComponent<SpriteRenderer>().color = tmp;
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
