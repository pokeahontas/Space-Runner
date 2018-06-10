using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayedStart : MonoBehaviour {

    private int time = 3;
    public Text t;


	// Use this for initialization
	void Start () {
        StartCoroutine("StartDelay");
	}
	
    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        t.text = "Get Ready!";


        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            time = time - 1;
            yield return 0;
        }

        t.text = "Go!";
        Time.timeScale = 1;
    }
}
