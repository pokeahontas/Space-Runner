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
    public ParticleSystem[] pSystems;
    public Material blue;
    public Material green;
    public Material yellow;
    private int lastColor;

     void Start()
    {
        pSystems[0].Stop();
        pSystems[1].Stop();
        pSystems[2].Stop();
        pSystems[3].Stop();
        pSystems[4].Stop();
    }

    void Update () {
        transform.position = player.transform.position;
        //print(LevelManagement.Instance.GetPlayer1Fast());
        if(isP1)
        {
            SetParticleSystemColor();
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
            SetParticleSystemColor();
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

    public void ActivateParticles(int pos, int amount)
    {
        //Debug.Log("pos: " + pos + ", amount: " + amount);
       
            for (int i = pos; i >= amount && i >= 0; i--)
            {
            //Debug.Log("i=" + i);
            //pSystems[i].Emit(20);
            StartCoroutine(ParticlesOverSeconds(0.4f,i));
            }
    }

    IEnumerator ParticlesOverSeconds(float duration, int whichSystem)
    {
        pSystems[whichSystem].Play();
        yield return new WaitForSeconds(duration);
        pSystems[whichSystem].Stop();
    }

    private void SetParticleSystemColor()
    {
        if(lastColor == 1)
        {
            foreach(ParticleSystem p in pSystems)
            {
                var main = p.main;
                main.startColor = Color.blue;
            }
        }
        else if(lastColor == 2)
        {
            foreach (ParticleSystem p in pSystems)
            {
                var main = p.main;
                main.startColor = Color.green;
            }
        }
        else if(lastColor == 3)
        {
            foreach (ParticleSystem p in pSystems)
            {
                var main = p.main;
                main.startColor = Color.yellow;
            }
        }
    }

    public void SetLastColor(int i)
    {
        lastColor = i;
    }
    public int GetLastColor()
    {
        return lastColor;
    }
}
