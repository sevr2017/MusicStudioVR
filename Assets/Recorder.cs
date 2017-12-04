using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Recorder : MonoBehaviour {
    public float maxTime=36000;

    private class Record
    {
        string instrument;
        Time time;
        float volumn;
        public Record (){}
        public Record(string i, float v) { instrument = i; volumn = v; }
        
    };

    private List<Record> soundRecords;
    private float endTime;
    private bool isRecording;
    private float timer;
    private bool isPlaying;

	// Use this for initialization
	void Start () {
        isRecording = false;
        soundRecords = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            startRecord();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stopRecord();
            endTime = timer;
        }
        if (isRecording == true) {
            if (timer >= maxTime * Time.deltaTime)
            {
                isRecording = false;
            }
            timer += Time.deltaTime;
        }

	}

    private void Reset()
    {
        timer = 0;
        soundRecords.Clear();
    }

    private void startRecord() {
        isRecording = true;
    }

    private void stopRecord() {
        isRecording = false;
    }

    public void doRecord(string instrument, float volumn) {
        soundRecords.Add(new Record(instrument, volumn));
    }
}
