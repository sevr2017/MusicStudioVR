using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariambaChilren : MonoBehaviour {

    public float pitch;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.pitch = pitch;
	}
}
