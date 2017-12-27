using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentButton : MonoBehaviour {

	public GameObject instrument;

	Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		button.onClick.AddListener(OnInstrumentButtonClick);
	}

	void OnInstrumentButtonClick(){
		if (instrument.activeInHierarchy == true) {
			instrument.SetActive (false);
		} else {
			instrument.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
