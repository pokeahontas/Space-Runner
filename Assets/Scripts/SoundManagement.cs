using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip cNote;
    public AudioClip dNote;
    public AudioClip eNote;
    public AudioClip gNote;
    public AudioClip aNote;

    Stack<string> ship1Melody = new Stack<string>();
    Stack<string> ship2Melody = new Stack<string>();

    private static SoundManagement _instance;

    public static SoundManagement Instance { get { return _instance; } }


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
    }

    public void PlayNote(string note, string ship)
    {
        if(note.Equals("c"))
        {
            audioSource.clip = cNote;
            audioSource.Play();
            if (ship.Equals("ship1"))
            {
                ship1Melody.Push("c");
            } 
            else
            {
                ship2Melody.Push("c");
            }
        }
        else if (note.Equals("d"))
        {
            audioSource.clip = dNote;
            audioSource.Play();
            if (ship.Equals("ship1"))
            {
                ship1Melody.Push("d");
            }
            else
            {
                ship2Melody.Push("d");
            }
        }
        else if (note.Equals("e"))
        {
            audioSource.clip = eNote;
            audioSource.Play();
            if (ship.Equals("ship1"))
            {
                ship1Melody.Push("e");
            }
            else
            {
                ship2Melody.Push("e");
            }
        }
        else if (note.Equals("g"))
        {
            audioSource.clip = gNote;
            audioSource.Play();
            if (ship.Equals("ship1"))
            {
                ship1Melody.Push("g");
            }
            else
            {
                ship2Melody.Push("g");
            }
        }
        else if (note.Equals("a"))
        {
            audioSource.clip = aNote;
            audioSource.Play();
            if (ship.Equals("ship1"))
            {
                ship1Melody.Push("a");
            }
            else
            {
                ship2Melody.Push("a");
            }
        }
    }

    public IEnumerator PlayEndMelody(string ship)
    {
        if(ship.Equals("ship1"))
        {
            foreach (string note in ship1Melody.BottomToTop)
            {
                print("ship1 endnote");
                print(note);
                PlayNote(note, "ship1");
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            foreach (string note in ship2Melody.BottomToTop)
            {
                print("ship2 endnote");
                PlayNote(note, "ship2");
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
