using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjTrigger : MonoBehaviour {
	public string djControllerTag = "DjController";

	public Transform controller;

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag != djControllerTag) {
			return;
		}
		if (controller == null) {
			controller = coll.transform;
		}
	}

	void OnTriggerStay(Collider coll){
		if (controller == null) {
			controller = coll.transform;
		}
	}

	void OnTriggerExit(Collider coll){
		if (controller != null)
			controller = null;
	}
}
