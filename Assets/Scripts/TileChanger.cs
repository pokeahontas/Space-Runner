using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChanger : MonoBehaviour {

    int last = 0;
    int now;
    public bool tiles1 = true;
    public bool tiles2 = false;
    public bool tiles3 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        now = LevelManagement.Instance.levelfarbe;

        if (now != last)
        {
            last = now;
            if (tiles1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles[now];
            }
            else if(tiles2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles2[now];
            }
            else if(tiles3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles3[now];
            }
        }
        
    }
}
