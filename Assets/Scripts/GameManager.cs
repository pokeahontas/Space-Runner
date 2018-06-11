using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private bool gameRunning;
    private bool whichInput; //true=Controller; false=keyboard

    void Start () {
        gameRunning = true;
        whichInput = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
