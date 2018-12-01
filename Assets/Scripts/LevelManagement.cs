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
            int[] tempArray = { 0, diamondBlue, diamondGreen, diamondYellow };
            // Finding max
            int m = tempArray.Max();
            // Positioning max
            int p = tempArray.ToList().IndexOf(m);

            levelfarbe = p;
        }
    }
}
