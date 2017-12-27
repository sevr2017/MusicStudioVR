using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    public AudioClip hitClip;
    public AudioSource drumAudio;
    [HideInInspector]
    public bool isPlaying=false;

    private void Awake()
    {
        drumAudio = GetComponent<AudioSource>();
        drumAudio.clip = hitClip;

    }
   
    public void play(float volume)
    {
       
            drumAudio.volume = volume;
            drumAudio.Play();
        isPlaying = true;
        
    }
    public void stop() {
        drumAudio.Stop();
        isPlaying = false;
    }

    public void setPitch(float i) {
        drumAudio.pitch = i;
    }
    public float getPitch() {
        return drumAudio.pitch;
    }
}
