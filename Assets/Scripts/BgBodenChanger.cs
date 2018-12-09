using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgBodenChanger : MonoBehaviour {

    int farbLast = 0;
    int farbNow;

    int bgLast = 0;
    int bgNow;

    //Baum
    public bool tiles1 = false;
    //plant
    public bool tiles2 = false;
    //Stein
    public bool tiles3 = false;
    //blume
    public bool tiles4 = false;
    //busch
    public bool tiles5 = false;


    public bool group1 = false;
    public bool group2 = false;
    public bool group3 = false;
    public bool group4 = false;
    public bool group5 = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        farbNow = LevelManagement.Instance.levelfarbe;
        bgNow = LevelManagement.Instance.hgBoden;

        if (farbNow != farbLast)
        {
            farbLast = farbNow;
            checkFarbe(farbNow);
            
        }
        if (bgNow != bgLast)
        {
            bgLast = bgNow;
            checkBg(bgNow);
        }

    }

    void checkFarbe(int tilenr)
    {
        if (tiles1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden1[farbNow];
        }
        else if (tiles2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden2[farbNow];
        }
        else if (tiles3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden3[farbNow];
        }
        else if (tiles4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden4[farbNow];
        }
        else if (tiles5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden5[farbNow];
        }
    }

    void checkBg(int bg)
    {
        if (bg >= 1 && group1)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (bg >= 2 && group2)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (bg >= 3 && group3)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (bg >= 4 && group4)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (bg >= 5 && group5)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
                    
    }
}
