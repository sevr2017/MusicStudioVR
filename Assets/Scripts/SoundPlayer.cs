using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    public AudioClip hitClip;
    AudioSource drumAudio;

    private void Awake()
    {
        drumAudio = GetComponent<AudioSource>();
        drumAudio.clip = hitClip;

    }
   
    public void play(float volume)
    {
       
            drumAudio.volume = volume;
            drumAudio.Play();
        
    }
}
