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

    void Update () {
        transform.position = player.transform.position;
        //print(LevelManagement.Instance.GetPlayer1Fast());
        if(isP1)
        {
            //if (LevelManagement.Instance.GetPlayer1Diamonds().Count > 0)
            //{
            //    if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 1) //blue
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia2.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia3.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia4.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia5.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //    }
            //    else if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 2) //green
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia2.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia3.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia4.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia5.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //    }
            //    else if (LevelManagement.Instance.GetPlayer1Diamonds()[LevelManagement.Instance.GetPlayer1Diamonds().Count - 1] == 3) //yellow
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia2.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia3.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia4.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia5.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //    }
            //}
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
            //if (LevelManagement.Instance.GetPlayer2Diamonds().Count > 0)
            //{
            //    if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 1) //blue
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia2.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia3.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia4.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //        dia5.GetComponent<Renderer>().material.color = new Color(102, 178, 255);
            //    }
            //    else if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 2) //green
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia2.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia3.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia4.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //        dia5.GetComponent<Renderer>().material.color = new Color(102, 255, 102);
            //    }
            //    else if (LevelManagement.Instance.GetPlayer2Diamonds()[LevelManagement.Instance.GetPlayer2Diamonds().Count - 1] == 3) //yellow
            //    {
            //        dia1.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia2.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia3.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia4.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //        dia5.GetComponent<Renderer>().material.color = new Color(255, 255, 51);
            //    }
            //}

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
