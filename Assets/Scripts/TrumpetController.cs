using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetController : MonoBehaviour {
    SoundPlayer sp;
    //AudioSource audiosou;
	// Use this for initialization
	void Start () {
        sp = GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {
            sp.play(1);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            sp.stop();

        }
    }

    void OnTriggerStay(Collider other)
    {

        float test = Vector3.Dot((other.transform.position - this.transform.position), transform.forward);
        float delta = (other.transform.position.z-this.transform.position.z)/(this.transform.localScale.z/2);
        sp.setPitch(1 + test);
        
        

    }
}
