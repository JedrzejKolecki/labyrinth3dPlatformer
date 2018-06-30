using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour //skrypt do sterowania audio
{
    public AudioClip[] pickUp; //lista dzwiekow
    public static bool play_Audio = false;
    public static bool play_Audio_Ghost = false;
    void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }
    public void Update()
    {
       if (play_Audio == true)
        {
            GetComponent<AudioSource>().PlayOneShot(pickUp[0], 1.0f);
            Debug.Log("COIN!");
        }
        play_Audio = false; 
        
        if (play_Audio_Ghost == true)
        {
            GetComponent<AudioSource>().PlayOneShot(pickUp[1], 1.0f);
            Debug.Log("GHOST!");
        }
       play_Audio_Ghost = false;
    }
}

