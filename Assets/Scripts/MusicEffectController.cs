using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Collider))]
public class MusicEffectController : MonoBehaviour {

	public AudioMixer musicMixer;
	public string paramName = "MusicLowpass";

	public float maxLowpass = 22000f;
	public float minLowpass = 1000f;

	public float currentLowpass = 22000f;

	public Collider inController;
	public Vector3 inPosition;
	public Vector3 inDirection;
	public float inMaxDistance;

	Collider effectCollider;

	void OnTriggerEnter(Collider coll){
		TrySetInController (coll);
	}

	void OnTriggerStay(Collider coll){
		TrySetInController (coll);
		if(coll == inController){
			Vector3 tickPos = coll.transform.position;
			Vector3 tickVector = tickPos - inPosition;
			float tickDistance = Vector3.Dot (tickVector, inDirection);

			float tickFactor = tickDistance / inMaxDistance;
			tickFactor = Mathf.Clamp (tickFactor, 0f, 1f);

			float tickOutput = Mathf.Lerp (maxLowpass, minLowpass, tickFactor);
			tickOutput = Mathf.Lerp (tickOutput, minLowpass, tickFactor);

			musicMixer.SetFloat (paramName, tickOutput);
			currentLowpass = tickOutput;
		}
	}


	void OnTriggerExit(Collider coll){
		if(inController == coll){
			inController = null;
			inPosition = inDirection = Vector3.zero;
			inMaxDistance = 0f;

			musicMixer.SetFloat (paramName, maxLowpass);
		}
	}

	void TrySetInController(Collider coll){
		if(inController == null){
			inController = coll;
			// inPosition = effectCollider.ClosestPoint(coll.transform.position);
			inPosition = coll.transform.position;
			inDirection = (transform.position - inPosition).normalized;
			inMaxDistance = Vector3.Distance (transform.position, inPosition) * 2f;
		}
	}

	// Use this for initialization
	void Start () {
		effectCollider = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
