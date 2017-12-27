using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrumpetController : MonoBehaviour {
    SoundPlayer sp;
    public Recorder recorder;
   // public ControllerManager manager;
    //AudioSource audiosou;
    // Use this for initialization
    void Start () {
        sp = GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L)/*||manager.rightControllerTouchDown.trigger*/) {
            play();

        }
        if (Input.GetKeyDown(KeyCode.K)/*||! manager.rightControllerTouchDown.trigger*/)
        {
            stop();

        }
    }

    void OnTriggerStay(Collider other)
    {

        float test = ((int)(Vector3.Dot((other.transform.position - this.transform.position), transform.forward)*3))/3.0f;
        float delta = (other.transform.position.z-this.transform.position.z)/(this.transform.localScale.z/2);
        
        if (sp.isPlaying == true) {
            if (!Mathf.Approximately(1+test,sp.getPitch())) { sp.setPitch(1 + test); recorder.doRecord(sp, 1, sp.getPitch(), InstrumentType.Trumpet, 0); }
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
