using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{

    public static Transform background1;
    public static Transform background2;
    public Transform cam1;

    private float currentPos1 = 40.96f;
    private bool whichOne = true;

    // Update is called once per frame
    void Start()
    {
        background1 = GameObject.Find("bg_neutral1").transform;
        background2 = GameObject.Find("bg_neutral2").transform;
    }

    void Update()
    {
        if (currentPos1 < cam1.position.x)
        {
            if (whichOne)
            {
                background1.localPosition = new Vector3(background1.localPosition.x + 81.92f, 0f, 0f);
            }
            else
            {
                background2.localPosition = new Vector3(background2.localPosition.x + 81.92f, 0f, 0f);
            }
            currentPos1 += 40.96f;

            whichOne = !whichOne;
        }
        if (currentPos1 > cam1.position.x + 40.96)
        {
            if (whichOne)
            {
                background2.localPosition = new Vector3(background2.localPosition.x - 81.92f, 0f, 0f);
            }
            else
            {
                background1.localPosition = new Vector3(background1.localPosition.x - 81.92f, 0f, 0f);
            }
            currentPos1 -= 40.96f;

            whichOne = !whichOne;
        }
    }

    public static void setBackgroundTheme(string theme)
    {
        if (theme.Equals("neutral"))
        {
            background1 = GameObject.Find("bg_neutral1").transform;
            background2 = GameObject.Find("bg_neutral2").transform;
        }
        else if (theme.Equals("forest"))
        {
            background1 = GameObject.Find("bg_forest1").transform;
            background2 = GameObject.Find("bg_forest2").transform;
        }
        else if (theme.Equals("desert"))
        {
            background1 = GameObject.Find("bg_desert1").transform;
            background2 = GameObject.Find("bg_desert2").transform;
        }
        else if (theme.Equals("snow"))
        {
            background1 = GameObject.Find("bg_snow1").transform;
            background2 = GameObject.Find("bg_snow2").transform;
        }
    }
}
