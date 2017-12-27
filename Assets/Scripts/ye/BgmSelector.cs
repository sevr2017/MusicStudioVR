using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSelector : MonoBehaviour {

    public AudioClip[] audioClips;
    Button button;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(changeBgm);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeBgm()
    {
        int tmp = Random.Range(0, audioClips.Length - 1);
        
        audioSource.clip = audioClips[tmp];
    }


}
