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
    public AudioClip testSound;

    Stack<string> ship1Melody = new Stack<string>();
    Stack<string> ship2Melody = new Stack<string>();

    public bool ship1Won;
    public bool ship2Won;
    public bool endMelodyPlayed;

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

        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if(!endMelodyPlayed)
            if(ship1Won)
            {

            }
            if (ship1Won)
            {

            }
    }

    public void PlayNote(string note, string ship, bool push)
    {
        if(note.Equals("c"))
        {
            audioSource.clip = cNote;
            audioSource.Play();
            if (ship.Equals("ship1") && push)
            {
                ship1Melody.Push("c");
            } 
            else if(ship.Equals("ship2") && push)
            {
                ship2Melody.Push("c");
            }
        }
        else if (note.Equals("d"))
        {
            audioSource.clip = dNote;
            audioSource.Play();
            if (ship.Equals("ship1") && push)
            {
                ship1Melody.Push("d");
            }
            else if (ship.Equals("ship2") && push)
            {
                ship2Melody.Push("d");
            }
        }
        else if (note.Equals("e"))
        {
            audioSource.clip = eNote;
            audioSource.Play();
            if (ship.Equals("ship1") && push)
            {
                ship1Melody.Push("e");
            }
            else if (ship.Equals("ship2") && push)
            {
                ship2Melody.Push("e");
            }
        }
        else if (note.Equals("g"))
        {
            audioSource.clip = gNote;
            audioSource.Play();
            if (ship.Equals("ship1") && push)
            {
                ship1Melody.Push("g");
            }
            else if (ship.Equals("ship2") && push)
            {
                ship2Melody.Push("g");
            }
        }
        else if (note.Equals("a"))
        {
            audioSource.clip = aNote;
            audioSource.Play();
            if (ship.Equals("ship1") && push)
            {
                ship1Melody.Push("a");
            }
            else if (ship.Equals("ship2") && push)
            {
                ship2Melody.Push("a");
            }
        }
    }

    public void PlayEndMelody(string ship)
    {
        AudioClip[] clipsToPlay;
        if (ship.Equals("ship1"))
        {
            clipsToPlay = NoteStringsToClipArray(ship1Melody);
            audioSource.clip = Combine(clipsToPlay);
            audioSource.Play();
        }
        else
        {
            clipsToPlay = NoteStringsToClipArray(ship2Melody);
            audioSource.clip = Combine(clipsToPlay);
            audioSource.Play();
        }
    }

    private AudioClip[] NoteStringsToClipArray(Stack<string> stackWithNotes)
    {
        AudioClip[] clips = new AudioClip[50];
        string[] noteArray = stackWithNotes.GetValues();
        
            int count = 0;
        print("WOHOOOOOOOOOOOO:   "+noteArray[0]);
        foreach (string s in noteArray)
        {
            if (s != null) {
                if (s.Equals("d"))
                {
                    print("bla");
                    clips[count] = cNote;
                    count++;
                }
                else if (s.Equals("d"))
                {
                    clips[count] = dNote;
                    count++;
                }
                else if (s.Equals("e"))
                {
                    clips[count] = eNote;
                    count++;
                }
                else if (s.Equals("g"))
                {
                    clips[count] = gNote;
                    count++;
                }
                else if (s.Equals("a"))
                {
                    clips[count] = aNote;
                    count++;
                }
            }
        }

        return clips;
    }

    public static AudioClip Combine(params AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0)
            return null;

        int length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            length += clips[i].samples * clips[i].channels;
        }

        float[] data = new float[length];
        length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            float[] buffer = new float[clips[i].samples * clips[i].channels];
            clips[i].GetData(buffer, 0);
            //System.Buffer.BlockCopy(buffer, 0, data, length, buffer.Length);
            buffer.CopyTo(data, length);
            length += buffer.Length;
        }

        if (length == 0)
            return null;

        AudioClip result = AudioClip.Create("Combine", length / 2, 2, 44100, false, false);
        result.SetData(data, 0);

        return result;
    }
}
