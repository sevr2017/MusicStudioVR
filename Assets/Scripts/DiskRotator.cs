using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRotator : MonoBehaviour {

	Rigidbody body;
	public float torque = 10f;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){

		body.AddTorque (transform.up * torque);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
