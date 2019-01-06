using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {

    public GameObject player;
    public bool isP1;
    public GameObject dia1;
    public GameObject dia2;
    public GameObject dia3;
    public GameObject dia4;
    public GameObject dia5;
    public Material blue;
    public Material green;
    public Material yellow;

    void Update () {
        transform.position = player.transform.position;
        //print(LevelManagement.Instance.GetPlayer1Fast());
        if(isP1)
        {
            if (LevelManagement.Instance.GetPlayer1Diamonds().Count > 0)
            {
                if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 1) //blue
                {
                    dia1.GetComponent<Renderer>().material = blue;
                    dia2.GetComponent<Renderer>().material = blue;
                    dia3.GetComponent<Renderer>().material = blue;
                    dia4.GetComponent<Renderer>().material = blue;
                    dia5.GetComponent<Renderer>().material = blue;
                }
                else if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 2) //green
                {
                    dia1.GetComponent<Renderer>().material = green;
                    dia2.GetComponent<Renderer>().material = green;
                    dia3.GetComponent<Renderer>().material = green;
                    dia4.GetComponent<Renderer>().material = green;
                    dia5.GetComponent<Renderer>().material = green;
                }
                else if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 3) //yellow
                {
                    dia1.GetComponent<Renderer>().material = yellow;
                    dia2.GetComponent<Renderer>().material = yellow;
                    dia3.GetComponent<Renderer>().material = yellow;
                    dia4.GetComponent<Renderer>().material = yellow;
                    dia5.GetComponent<Renderer>().material = yellow;
                }
            }
            List<int> p1Diamonds = LevelManagement.Instance.GetPlayer1Diamonds();
            if (LevelManagement.Instance.GetPlayer1Fast() == 0)
            {
                dia1.GetComponent<Renderer>().enabled = false;
                dia2.GetComponent<Renderer>().enabled = false;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer1Fast() == 1)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = false;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer1Fast() == 2)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer1Fast() == 3)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer1Fast() == 4)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = true;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer1Fast() == 5)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = true;
                dia5.GetComponent<Renderer>().enabled = true;

            }
        }
        else
        {
            if (LevelManagement.Instance.GetPlayer2Diamonds().Count > 0)
            {
                if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 1) //blue
                {
                    dia1.GetComponent<Renderer>().material = blue;
                    dia2.GetComponent<Renderer>().material = blue;
                    dia3.GetComponent<Renderer>().material = blue;
                    dia4.GetComponent<Renderer>().material = blue;
                    dia5.GetComponent<Renderer>().material = blue;
                }
                else if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 2) //green
                {
                    dia1.GetComponent<Renderer>().material = green;
                    dia2.GetComponent<Renderer>().material = green;
                    dia3.GetComponent<Renderer>().material = green;
                    dia4.GetComponent<Renderer>().material = green;
                    dia5.GetComponent<Renderer>().material = green;
                }
                else if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 3) //yellow
                {
                    dia1.GetComponent<Renderer>().material = yellow;
                    dia2.GetComponent<Renderer>().material = yellow;
                    dia3.GetComponent<Renderer>().material = yellow;
                    dia4.GetComponent<Renderer>().material = yellow;
                    dia5.GetComponent<Renderer>().material = yellow;
                }
            }

            List<int> p2Diamonds = LevelManagement.Instance.GetPlayer2Diamonds();
            if (LevelManagement.Instance.GetPlayer2Fast() == 0)
            {
                dia1.GetComponent<Renderer>().enabled = false;
                dia2.GetComponent<Renderer>().enabled = false;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer2Fast() == 1)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = false;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer2Fast() == 2)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = false;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer2Fast() == 3)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = false;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer2Fast() == 4)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = true;
                dia5.GetComponent<Renderer>().enabled = false;
            }
            else if (LevelManagement.Instance.GetPlayer2Fast() == 5)
            {
                dia1.GetComponent<Renderer>().enabled = true;
                dia2.GetComponent<Renderer>().enabled = true;
                dia3.GetComponent<Renderer>().enabled = true;
                dia4.GetComponent<Renderer>().enabled = true;
                dia5.GetComponent<Renderer>().enabled = true;
            }
        }
	}
}
