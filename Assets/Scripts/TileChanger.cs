using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChanger : MonoBehaviour {

    int last = 0;
    int now;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        now = LevelManagement.Instance.levelfarbe;

        if (now != last)
        {
            last = now;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.tiles[now];
        }
        
    }
}
