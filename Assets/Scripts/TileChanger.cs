using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChanger : MonoBehaviour {

    int last = 0;
    int now;
    public bool above = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        now = LevelManagement.Instance.levelfarbe;

        if (now != last)
        {
            last = now;
            if (above)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles[now];
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles2[now];
            }
        }
        
    }
}
