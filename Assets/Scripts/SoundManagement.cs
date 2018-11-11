using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour {

    public AudioSource audioSource;

    //public AudioSource cNote;
    //public AudioSource dNote;
    //public AudioSource eNote;
    //public AudioSource gNote;
    //public AudioSource aNote;

    public AudioClip cNote;
    public AudioClip dNote;
    public AudioClip eNote;
    public AudioClip gNote;
    public AudioClip aNote;

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

    public void PlayNote(string note)
    {
        if(note.Equals("c"))
        {
            audioSource.clip = cNote;
            audioSource.Play();
        }
        else if (note.Equals("d"))
        {
            audioSource.clip = dNote;
            audioSource.Play();
        }
        else if (note.Equals("e"))
        {
            audioSource.clip = eNote;
            audioSource.Play();
        }
        else if (note.Equals("g"))
        {
            audioSource.clip = gNote;
            audioSource.Play();
        }
        else if (note.Equals("a"))
        {
            audioSource.clip = aNote;
            audioSource.Play();
        }
    }
}
