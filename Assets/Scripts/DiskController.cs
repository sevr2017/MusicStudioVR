using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskController : MonoBehaviour {
	public float _hotDegree1=0;
	public float _hotDegree2=0;
	public ControllerManager manager;
	public GameObject leftDisk;
	public GameObject rightDisk;
	public Transform originalLeftPoint;
	public Transform originalRightPoint;
	public float normalDegree;
	public int startingPitch;
	
	private Vector3 xVector, yVector, zVector;
	private Vector3 leftFootPoint, rightFootPoint;
	private Vector3 steeringWheelVectorLeft;
	private Vector3 steeringWheelVectorRight;
	private AudioSource leftAudio;
	private AudioSource rightAudio;
	public float leftDegree;
	public float rightDegree;
	
	
	// Use this for initialization
	void Start () {
		
		if(leftDisk != null)

		{

			Renderer render1 = leftDisk.GetComponent<Renderer>();

			render1.material.color = Color.green;
			leftAudio = leftDisk.GetComponent<AudioSource> ();
			leftAudio.pitch = startingPitch;

		}

		if(rightDisk != null)

		{

			Renderer render2 = rightDisk.GetComponent<Renderer>();

			render2.material.color = Color.red;
			rightAudio = rightDisk.GetComponent<AudioSource> ();
			rightAudio.pitch = startingPitch;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (manager == null || originalLeftPoint == null || originalRightPoint == null ) {
			return;
		}
		leftDegree = 0;
		rightDegree  = 0;
		if (manager.rightTriggerAxis.x>0) {
			print("control by right trigger");
			
			steeringWheelVectorRight = new Vector3(originalRightPoint.position.x-manager.rightControllerPosition.x,originalRightPoint.position.y,originalRightPoint.position.z-manager.rightControllerPosition.z); //- leftFootPoint;
			
			float tmpDegree1 = Vector3.Angle (steeringWheelVectorRight, new Vector3(0,0,1));
			Debug.Log("NOWDegree : "+ tmpDegree1);
			rightDegree=tmpDegree1-_hotDegree1;
			Debug.Log("NOWDegree : "+ rightDegree);
			_hotDegree1=tmpDegree1;
			

		} 

		if (manager.leftTriggerAxis.x>0) {
			print("control by right trigger");
			
			steeringWheelVectorLeft = new Vector3(originalLeftPoint.position.x-manager.leftControllerPosition.x,originalLeftPoint.position.y,originalLeftPoint.position.z-manager.leftControllerPosition.z); //- leftFootPoint;
			
			float tmpDegree2 = Vector3.Angle (steeringWheelVectorLeft, new Vector3(0,0,1));
			Debug.Log("NOWDegree : "+ tmpDegree2);
			leftDegree=tmpDegree2-_hotDegree2;
			Debug.Log("NOWDegree : "+ leftDegree);
			_hotDegree2=tmpDegree2;
		}
		leftDisk.transform.Rotate(0,normalDegree+leftDegree*2,0);
		rightDisk.transform.Rotate(0,-rightDegree*2-normalDegree,0);

		leftAudio.pitch -= leftDegree*0.005f;//Time.deltaTime * 0.2f;
		rightAudio.pitch -= rightDegree*0.005f;//Time.deltaTime * 0.2f;

	}
}
