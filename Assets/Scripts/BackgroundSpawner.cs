using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{

    public Transform background1;
    public Transform background2;
    public Transform cam1;

    private float currentPos1 = 40.96f;
    private bool whichOne = true;

    // Update is called once per frame
    void Update()
    {
        if (currentPos1 < cam1.position.x)
        {
            if (whichOne)
            {
                background1.localPosition = new Vector3(background1.localPosition.x + 81.92f, 2.6f, 0f);
            }
            else
            {
                background2.localPosition = new Vector3(background2.localPosition.x + 81.92f, 2.6f, 0f);
            }
            currentPos1 += 40.96f;

            whichOne = !whichOne;
        }
        if (currentPos1 > cam1.position.x + 40.96)
        {
            if (whichOne)
            {
                background2.localPosition = new Vector3(background2.localPosition.x - 81.92f, 2.6f, 0f);
            }
            else
            {
                background1.localPosition = new Vector3(background1.localPosition.x - 81.92f, 2.6f, 0f);
            }
            currentPos1 -= 40.96f;

            whichOne = !whichOne;
        }
    }
}
