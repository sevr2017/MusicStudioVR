using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordClearButton : MonoBehaviour {

    public Recorder recorder;

    Button button;

    Text buttonText;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        button.onClick.AddListener(OnRecordClearButtonClicked);
    }
		
    void OnRecordClearButtonClicked()
    {
		recorder.Reset ();
    }
}
