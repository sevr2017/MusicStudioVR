using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Collider))]
public class MusicEffectController : MonoBehaviour {

	public AudioMixer musicMixer;
	public string lowpassParamName = "MusicLowpass";

	public float defaultLowpass = 22000f;
	public float maxLowpass = 22000f;
	public float minLowpass = 1000f;

	public float currentLowpass = 22000f;

	public string flangeDry = "MusicFlangeDry";
	public string flangeWet = "MusicFlangeWet";
	public string flangeRate = "MusicFlangeRate";

	public float maxRate = 0.5f;
	public float minRate = 0.01f;
	[Range(0f, 1f)]
	public float dryFactor = 0.45f;
	public float deadZone = 0.2f;

	public Collider inController;
	public Vector3 inPosition;
	public Vector3 inDirection;
	public Vector3 inVelocity;
	public float inMaxDistance;

	public Color startColor = Color.white;
	public Color endColor = Color.red;
	public Color flangeEndColor = Color.green;

	public AnimationCurve curve;

	Collider effectCollider;
	Renderer rend;

	void OnTriggerEnter(Collider coll){
		TrySetInController (coll);
	}

	void OnTriggerStay(Collider coll){
		TrySetInController (coll);
		if(coll == inController){
			float tickFactor = GetTangentTickFactor (coll);
			float tickFactorCurve = curve.Evaluate (tickFactor);
			// float tickFactorDamp = Mathf.Lerp (tickFactor, tickFactor, 1f);

			float tickOutput = Mathf.Lerp (maxLowpass, minLowpass, tickFactorCurve);
			musicMixer.SetFloat (lowpassParamName, tickOutput);
			currentLowpass = tickOutput;
			//tickOutput = Mathf.Lerp (tickOutput, minLowpass, tickFactor);

			Color lowpassColor = Color.Lerp (startColor, endColor, tickFactor);
			rend.material.SetColor ("_Color", lowpassColor);

			tickFactor = GetVerticalTickFactor (coll);
//			Debug.Log (tickFactor);
			if(tickFactor > deadZone){
				tickFactor = (tickFactor - deadZone) / (1f - deadZone);
				float rateOutput = Mathf.Lerp (minRate, maxRate, tickFactor);
				musicMixer.SetFloat (flangeDry, dryFactor);
				musicMixer.SetFloat (flangeWet, 1f - dryFactor);
				musicMixer.SetFloat (flangeRate, rateOutput);

				Color flangeColor = Color.Lerp (startColor, flangeEndColor, tickFactor);
				Color final = flangeColor * lowpassColor;
				rend.material.SetColor ("_Color", final);

			} else {
				ResetFlange ();
			}
		}
	}


	// along the inDirection
	float GetTangentTickFactor(Collider coll){
		Vector3 tickPos = coll.transform.position;
		Vector3 tickVector = tickPos - inPosition;
		float tickDistance = Vector3.Dot (tickVector, inDirection);

		float tickFactor = tickDistance / inMaxDistance;
		tickFactor = Mathf.Clamp (tickFactor, 0f, 1f);
		return tickFactor;
	}

	// perpendicular to inDirection
	float GetVerticalTickFactor(Collider coll){
		Vector3 tickPos = coll.transform.position;
		Vector3 tickVector = tickPos - inPosition;
		float tickDistance = Vector3.Dot (tickVector, inVelocity);
		tickDistance = Mathf.Sqrt (tickVector.sqrMagnitude - Mathf.Pow(tickDistance, 2f));

		float tickFactor = tickDistance / (inMaxDistance / 2.0f);
		tickFactor = Mathf.Clamp (tickFactor, 0f, 1f);
		return tickFactor;
	}


	void OnTriggerExit(Collider coll){
		if(inController == coll){
			inController = null;
			inVelocity = inPosition = inDirection = Vector3.zero;
			inMaxDistance = 0f;

			ResetLowpass ();
			ResetFlange ();
		}
	}

	void ResetFlange(){
		musicMixer.SetFloat (flangeDry, 1f);
		musicMixer.SetFloat (flangeWet, 0f);
		musicMixer.SetFloat (flangeRate, 0f);
	}

	void ResetLowpass(){
		musicMixer.SetFloat (lowpassParamName, defaultLowpass);
		rend.material.SetColor ("_Color", startColor);
	}

	void TrySetInController(Collider coll){
		if(inController == null){
			inController = coll;
			inPosition = effectCollider.ClosestPoint(coll.transform.position);
			// inPosition = coll.transform.position;
			inDirection = (transform.position - inPosition).normalized;

			FakeVelocity fv = coll.GetComponent<FakeVelocity> ();
			if(fv == null){
				Debug.Log ("does not have fake velocity");
				inVelocity = inDirection;

			} else {
				Debug.Log ("have fake velocity");
				inVelocity = coll.GetComponent<FakeVelocity> ().lastNonZeroVelocity.normalized;
			}

			inMaxDistance = Vector3.Distance (transform.position, inPosition) * 2f;
		}
	}

	// Use this for initialization
	void Start () {
		effectCollider = GetComponent<Collider> ();
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
