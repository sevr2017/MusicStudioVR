using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrumpetController : MonoBehaviour {
    SoundPlayer sp;
    public Recorder recorder;
    private bool canPlay;
    public GameObject push1;
    public GameObject push2;
    public GameObject push3;
    // public ControllerManager manager;
    //AudioSource audiosou;
    // Use this for initialization

    private float upDist=0.1f;
    void Start () {
        sp = GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.L)/*||manager.rightControllerTouchDown.trigger*/)
        {
            //play();
            Debug.Log("can play");
            canPlay = true;
        }
        else {
            canPlay = false;
        }
        //if (Input.GetKeyDown(KeyCode.K)/*||! manager.rightControllerTouchDown.trigger*/)
        //{
        //    stop();
        //    canPlay = false;
        //}
    }

    void OnTriggerStay(Collider other)
    {

        float test = ((int)(Vector3.Dot((other.transform.position - this.transform.position), transform.forward)/(transform.localScale.z/2)*3))/3.0f;
        float delta = (other.transform.position.z-this.transform.position.z)/(this.transform.localScale.z/2);
        Debug.Log(test);
        float animate = (Vector3.Dot((other.transform.position - this.transform.position), transform.forward) / (transform.localScale.z / 2));//-1 ~ 1

        if (canPlay == true)
        {

            if (sp.isPlaying == true)
            {
                if (!Mathf.Approximately(1 + test, sp.getPitch())) { sp.setPitch(1 + test); recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, 0); }
            }
            else
            {
                Debug.Log("start trumpet");
                play();
                if (!Mathf.Approximately(1 + test, sp.getPitch())) { sp.setPitch(1 + test); recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, 0); }
            }
            float push1ratio = ((animate + 1.0f) / 2.0f)/*0~1*// (1.0f / 3.0f);
            float push2ratio = ((animate + 1.0f) / 2.0f-1.0f/3.0f)/*0~1*// (1.0f / 3.0f);
            float push3ratio = ((animate + 1.0f) / 2.0f-2.0f/3.0f)/*0~1*// (1.0f / 3.0f);
            if (push1ratio < 0) { push1ratio = 0; }
            else if (push1ratio > 1) { push1ratio = 1; }
            if (push2ratio < 0) { push2ratio = 0; }
            else if (push2ratio > 1) { push2ratio = 1; }
            if (push3ratio < 0) { push3ratio = 0; }
            else if (push3ratio > 1) { push3ratio = 1; }
            push1.transform.localPosition = new Vector3(push1.transform.localPosition.x,  push1ratio, push1.transform.localPosition.z);
            push2.transform.localPosition = new Vector3(push2.transform.localPosition.x,  push2ratio, push2.transform.localPosition.z);
            push3.transform.localPosition = new Vector3(push3.transform.localPosition.x,  push3ratio, push3.transform.localPosition.z);
        }
        else {
            sp.stop();
            recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, -1);
        }
        
        
        

    }
    void play() {
        sp.play(1);
        recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, 1);
    }
    void stop() {
        sp.stop();
        recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, -1);
    }
}
