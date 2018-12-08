using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgBodenChanger : MonoBehaviour {

    int last = 0;
    int now;
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        now = LevelManagement.Instance.levelfarbe;

        if (now != last)
        {
            last = now;
            check(now);
        }
        
    }

    void check(int tilenr)
    {
        if (tiles1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden1[now];
        }
        else if (tiles2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden2[now];
        }
        else if (tiles3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden3[now];
        }
        else if (tiles4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden4[now];
        }
        else if (tiles5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.BgBoden5[now];
        }
    }
}
