using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStickContoller : MonoBehaviour {

    private float openAngle = 70;
    private float RotationGap = 2;

    public GameObject stick;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")) {
            //Debug.Log("here");
            stick.transform.position-=new Vector3(0,0.02f,0);
            //StartCoroutine(StickHit());
        }
        if (Input.GetButtonUp("Fire1")) {
            stick.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            stick.transform.localPosition = new Vector3(0, 0, stick.transform.localPosition.z);
        }
	}

    IEnumerator StickHit() {
        while (transform.localEulerAngles.z < openAngle || transform.localEulerAngles.z <= 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + RotationGap);
            yield return 0;
        }
        while (transform.localEulerAngles.z >= 0) {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - RotationGap);
            yield return 0;
        }
    }

 }
