using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondChanger : MonoBehaviour {

    private bool start;

    public GameObject yellow;
    public GameObject blue;
    public GameObject green;

    private int randomnNumber;

	// Use this for initialization
	void Start () {
        start = false;
    }
	
	void Update () {
		if (!start)
        {
            randomnNumber = Random.Range(1, 4);
            switch (randomnNumber)
            {
                case 1:
                    Instantiate(green, this.transform);
                    break;
                case 2:
                    Instantiate(yellow, this.transform);
                    break;
                case 3:
                    Instantiate(blue, this.transform);
                    break;
            }
            start = true;
        }
	}
}
