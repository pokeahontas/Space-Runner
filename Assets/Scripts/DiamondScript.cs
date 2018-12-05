using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

    public GameObject scoreP1;
    public GameObject scoreP2;

    public int incAmount;

    // Use this for initialization
    void Start () {
        incAmount = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "collectible")
        {
            if (collision.gameObject.tag == "Ship1")
            {
                SoundManagement.Instance.PlayNote("d", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(3, 1);
            }
            else if (collision.gameObject.tag == "Ship2")
            {
                SoundManagement.Instance.PlayNote("d", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(3, 1);
            }
        }
        else if (this.gameObject.tag == "collectibleBlue")
        {
            if (collision.gameObject.tag == "Ship1")
            {
                SoundManagement.Instance.PlayNote("e", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(1, 1);
            }
            else if (collision.gameObject.tag == "Ship2")
            {
                SoundManagement.Instance.PlayNote("e", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(1, 1);
            }
            
        }
        else if (this.gameObject.tag == "collectibleGreen")
        {
            if (collision.gameObject.tag == "Ship1")
            {
                SoundManagement.Instance.PlayNote("a", "ship1", true);
                scoreP1.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(2, 1);
            }
            else if (collision.gameObject.tag == "Ship2")
            {
                SoundManagement.Instance.PlayNote("e", "ship2", true);
                scoreP2.GetComponent<Score>().inc(incAmount);
                LevelManagement.Instance.updateDiamond(2, 1);
            }
            
        }

        Destroy(this.transform.parent.gameObject);
        
    }
}
