using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    bool isplay = false;

    public Recorder recorder;

    Button button;

    Text buttonText;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        button.onClick.AddListener(OnPlayButtonClicked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlayButtonClicked()
    {
        if (isplay == false)
        {
            buttonText.text = "Stop playing record";
            recorder.startPlay();
			isplay = true;
        }
        else if( isplay == true)
        {
            buttonText.text = "Start playing record";
			recorder.stopPlay();
			isplay = false;
        }
    }
}
