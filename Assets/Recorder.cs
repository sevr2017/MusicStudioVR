using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Recorder : MonoBehaviour {
    public long maxTime=36000;
    private List<Record> soundRecords;
    private long endTime;

    private static long recordTimer;
    private bool isRecording;
    private static long playTimer;
    private bool isPlaying;

    private class Record
    {
        SoundPlayer instrumentSP;
        public long time;
        float volume;
        public Record (){}
        public Record(SoundPlayer i, float v) { Debug.Log("record time:"+recordTimer); instrumentSP = i; volume = v; time = recordTimer; }

        public void Play() {
            instrumentSP.play(volume);
        }
        
    };

   

	// Use this for initialization
	void Start () {
        isRecording = false;
        soundRecords = null;
        soundRecords = new List<Record>();
        recordTimer = 0;
        playTimer = 0;
        endTime = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.R)) {

            startRecord();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stopRecord();
            endTime = recordTimer;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            stopRecord();
            startPlay();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            stopPlay();
        }
        if (isRecording == true)
        {
            if (recordTimer >= maxTime)
            {
                isRecording = false;
            }
            recordTimer += 1;
        }
        else { recordTimer = 0; }

        if (isPlaying == true)
        {
            foreach (Record i in soundRecords)
            {
                Debug.Log("my time:" + i.time + " player timer:" + playTimer);
                if (i.time == playTimer)
                {
                    Debug.Log("play success!!");
                    i.Play();
                }
            }
            playTimer += 1;
            if (playTimer == endTime) { playTimer = 0; }//loop
        }
        else { playTimer = 0; }

	}

    private void Reset()
    {
        recordTimer = 0;
        playTimer = 0;
        soundRecords.Clear();
    }

    private void startRecord() {
        Debug.Log("start recording!!");
        recordTimer = 0;
        isRecording = true;
    }

    private void stopRecord() {
        Debug.Log("stop recording!!");
        endTime = recordTimer;
        isRecording = false;
    }

    public void doRecord(SoundPlayer instrument, float volumn) {
        if (isRecording)
        {
            Debug.Log("sound recorded!!"+volumn);
            soundRecords.Add(new Record(instrument, volumn));
        }
    }

    public void startPlay() {
        Debug.Log("start playing!!");
        isPlaying = true;
    }
    public void stopPlay()
    {
        playTimer = 0;
        isPlaying = false;
    }
}
