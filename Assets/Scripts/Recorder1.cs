using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum InstrumentType { Drum, Trumpet };
//public class RecordSoundPlayer 
//{
//    public AudioClip hitClip;
//    AudioSource drumAudio;
//    [HideInInspector]
//    public bool isPlaying = false;

//    public RecordSoundPlayer(SoundPlayer sp) {
//        this.hitClip = sp.hitClip;
//        this.drumAudio = sp.drumAudio;
//    }

//    public void play(float volume)
//    {

//        drumAudio.volume = volume;
//        drumAudio.Play();
//        isPlaying = true;

//    }
//    public void stop()
//    {
//        drumAudio.Stop();
//        isPlaying = false;
//    }

//    public void setPitch(float i)
//    {
//        drumAudio.pitch = i;
//    }
//    public float getPitch()
//    {
//        return drumAudio.pitch;
//    }
//}
//public class Recorder1 : MonoBehaviour {
   

//    public long maxTime=36000;
//    private List<Record> soundRecords;
//    private long endTime;

//    private static long recordTimer;
//    private bool isRecording;
//    private static long playTimer;
//    private bool isPlaying;

//    private class Record
//    {
//        public RecordSoundPlayer instrumentSP;
//        public InstrumentType type;
//        public long time;
//        public float volume;
//        public int state;
//        public float pitch;
//        public Record (){}
//        public Record(RecordSoundPlayer i, float v, InstrumentType t) {  instrumentSP = i; volume = v; time = recordTimer; type = t; }
//        public Record(RecordSoundPlayer i, float v, float p, InstrumentType t, int s) { instrumentSP = i; volume = 1; time = recordTimer; type = t; pitch = p; state = s; }

//        public void Play() {
//            instrumentSP.play(volume);
//        }
//        public void Stop() {
//            instrumentSP.stop();
//        }
        
//    };

   

//	// Use this for initialization
//	void Start () {
//        isRecording = false;
//        soundRecords = null;
//        soundRecords = new List<Record>();
//        recordTimer = 0;
//        playTimer = 0;
//        endTime = 0;
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.R))
//        {

//            startRecord();
//        }
//        if (Input.GetKeyDown(KeyCode.D))
//        {

//            Reset();
//        }
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            stopRecord();
            
//        }
//        if (Input.GetKeyDown(KeyCode.P))
//        {
//            //stopRecord();
//            startPlay();
//        }
//        if (Input.GetKeyDown(KeyCode.O))
//        {
//            stopPlay();
//        }
//    }

//    // Update is called once per frame
//    void FixedUpdate () {
       
//        if (isRecording == true)
//        {
//            if (recordTimer >= maxTime)
//            {
//                isRecording = false;
//            }
//            recordTimer += 1;
//        }
//        else { recordTimer = 0; }

//        if (isPlaying == true)
//        {
//            foreach (Record i in soundRecords)
//            {
//               // Debug.Log("my time:" + i.time + " player timer:" + playTimer);
//                if (i.time == playTimer)
//                {
//                    //Debug.Log("play success!!");
//                    if (i.type == InstrumentType.Drum)
//                    {
//                        i.Play();
//                    }
//                    else if (i.type == InstrumentType.Trumpet) {
//                        Debug.Log("trumpet log:" + i.state + "  " + i.pitch);
//                        if (i.state == 1) { i.instrumentSP.setPitch(i.pitch); i.instrumentSP.play(1); }
//                        else if (i.state == 0) { i.instrumentSP.setPitch(i.pitch); Debug.Log("trumpet pitch:" +i.instrumentSP.getPitch()); }
//                        else if (i.state == -1) { i.instrumentSP.stop(); }
//                    }
                    
//                }
//            }
//            playTimer += 1;
//            if (playTimer == endTime) { playTimer = 0; }//loop
//        }
//        else { playTimer = 0; }

//	}

//    private void Reset()
//    {
//        recordTimer = 0;
//        playTimer = 0;
//        endTime = 0;
//        isPlaying = false;
//        isRecording = false;
//        soundRecords.Clear();
//    }

//    private void startRecord() {
//        Debug.Log("start recording!!");
//        playTimer = 0;
//        recordTimer = 0;
//        isRecording = true;
//    }

//    private void stopRecord() {
//        Debug.Log("stop recording!!");
//        if (endTime <= recordTimer) {
//            if (soundRecords[soundRecords.Count - 1].time >= endTime) {
//                endTime = recordTimer;
//            }
//            //endTime = recordTimer;
//        }
        
//        isRecording = false;
//    }

//    public void doRecord(SoundPlayer instrument, float volumn, InstrumentType type) {
//        if (isRecording)
//        {
//            Debug.Log("sound recorded!!"+volumn);
            
//            soundRecords.Add(new Record(new RecordSoundPlayer(instrument), volumn,type));
//        }
//    }

//    public void doRecord(SoundPlayer instrument, float volumn, float pitch, InstrumentType type,int state)
//    {
//        if (isRecording)
//        {
//            Debug.Log("sound recorded!!" + volumn);
//            RecordSoundPlayer tmp = new RecordSoundPlayer(instrument);
            
//            soundRecords.Add(new Record(tmp, volumn, pitch, type, state));
//        }
//    }

//    public void startPlay() {
//        Debug.Log("start playing!!");
//        isPlaying = true;
//    }
//    public void stopPlay()
//    {
//        Debug.Log("stop playing!!");
//        playTimer = 0;
//        isPlaying = false;
//    }
//}
