using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter(Collider other){
		if (transform.gameObject.name != "Cube" && other.gameObject.name=="Cube") {
			print ("hit "+transform.gameObject.name +" speed: " + other.GetComponent<Collider>().attachedRigidbody.velocity.magnitude);
		}
	}
}
