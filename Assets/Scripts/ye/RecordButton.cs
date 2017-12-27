using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordButton : MonoBehaviour {
    
    bool isRecord = false;

    public Recorder recorder;

    Button button;

    Text buttonText;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        button.onClick.AddListener(OnRecordButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnRecordButtonClicked()
    {
        if (isRecord == false)
        {
            buttonText.text = "Stop recording";
			recorder.startRecord ();
            isRecord = true;
        }
        else if (isRecord == true)
        {
            buttonText.text = "Start recording";
			recorder.stopRecord();
            isRecord = false;
        }
    }
}
