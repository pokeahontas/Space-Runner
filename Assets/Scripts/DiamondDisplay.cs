using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDisplay : MonoBehaviour {

    public bool ship1;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)    //int i = 0; i < 15; i++
        {
            if (ship1)
            {
                if (LevelManagement.Instance.player1Diamonds.Count > i)
                {
                    
                    if (LevelManagement.Instance.player1Diamonds[i] == 1)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[1];
                    }
                    else if (LevelManagement.Instance.player1Diamonds[i] == 2)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[2];
                    }
                    else if (LevelManagement.Instance.player1Diamonds[i] == 3)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[3];
                    }
                }
                else
                {
                    this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[0];
                }
            }
            else
            {
                if (LevelManagement.Instance.player2Diamonds.Count > i)
                {

                    if (LevelManagement.Instance.player2Diamonds[i] == 1)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[1];
                    }
                    else if (LevelManagement.Instance.player2Diamonds[i] == 2)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[2];
                    }
                    else if (LevelManagement.Instance.player2Diamonds[i] == 3)
                    {
                        this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[3];
                    }
                }
                else
                {
                    this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = LevelManagement.Instance.diamonds[0];
                }
            }
        }
    }
}
