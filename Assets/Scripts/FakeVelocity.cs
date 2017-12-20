using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeVelocity : MonoBehaviour {

    Vector3 lastPos;

    public Vector3 velocity;
	public Vector3 lastNonZeroVelocity;

	// Use this for initialization
	void Start () {
        lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        velocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;

		if(velocity.magnitude > 0f){
			lastNonZeroVelocity = velocity;
		}
	}
}
