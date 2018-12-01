using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManagement : MonoBehaviour {

    private static LevelManagement _instance;

    public static LevelManagement Instance { get { return _instance; } }

    int diamondBlue = 0;
    int diamondGreen = 0;
    int diamondYellow = 0;

    public Sprite[] tiles = new Sprite[4];

    public int levelfarbe = 0;
    public int hgBoden = 0;
    public int hgWeit = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void updateDiamond(int color, int value)
    {
        if (color == 1)
        {
            diamondBlue += value;
        }
        else if (color == 2)
        {
            diamondGreen += value;
        }
        else if (color == 3)
        {
            diamondYellow += value;
        }
        print("Blue: " + diamondBlue + " Green: " + diamondGreen + " Yellow: " + diamondYellow);


        if (diamondBlue + diamondGreen + diamondYellow == 0)
        {
            levelfarbe = 0;
        }
        else
        {
            int[] tempArray = { diamondBlue, diamondGreen, diamondYellow };
            
            int max = tempArray.Max();
            int min = tempArray.Min();
            int secondHighest = (from number in tempArray orderby number descending select number).Distinct().Skip(1).First();
   
            int p = tempArray.ToList().IndexOf(max);
            levelfarbe = p+1;

            //Entfernung von unentschieden
            hgBoden = max - secondHighest;

            //Entfernung von Minimum
            hgWeit = max - min;

        }
    }
}
