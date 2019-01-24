using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public Object nextScene;
    public bool endScreen;
    public TextMeshProUGUI winnerText;
    private bool p1Ready;
    private bool p2Ready;
    private bool sceneAlreadyLoaded;
    public TextMeshProUGUI p1readyText;
    public TextMeshProUGUI p2readyText;
    public TextMeshProUGUI p1pressText;
    public TextMeshProUGUI p2pressText;
    public Image aButton1;
    public Image aButton2;
    

    void Start () {
        p1Ready = false;
        p2Ready = false;
        p1readyText.enabled = false;
        p2readyText.enabled = false;
        sceneAlreadyLoaded = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (endScreen)
        {
            if (LevelManagement.Instance.winner == 1)
            {
                winnerText.text = "Player 1 Won!";
            }
            else if (LevelManagement.Instance.winner == 2)
            {
                winnerText.text = "Player 2 Won!";
            }
        }

		if(Input.GetButton("Gravity1"))
        {
            Debug.Log("P1 pressed");
            p1Ready = true;
            p1readyText.enabled = true;
            p1pressText.enabled = false;
            aButton1.enabled = false;
        }
        if(Input.GetButton("Gravity2"))
        {
            Debug.Log("P2 pressed");
            p2Ready = true;
            p2readyText.enabled = true;
            p2pressText.enabled = false;
            aButton2.enabled = false;
        }

        if(p1Ready && p2Ready && !sceneAlreadyLoaded)
        {
            if (endScreen)
            {   
                //Dirty but works
                Destroy(LevelManagement.Instance);
            }
            SceneManager.LoadScene(nextScene.name);
            sceneAlreadyLoaded = true;
        }
	}
}
