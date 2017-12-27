using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DoorController : MonoBehaviour {
    public UnityStandardAssets.Vehicles.Car.CarController carController;
    public ControllerManager manager;
    // public Transform Door;
    //private bool opened = false;
    private float openAngle = 360-75;
    private bool isOpening = false;
    private float RotationGap = 0.5f;


    private void Update()
    {
        bool open ;
        
        if (Mathf.Abs(carController.CurrentSpeed) > 1&& Mathf.Abs(carController.CurrentSpeed)<3) {
            isOpening = false;
            StartCoroutine(OperateDoor(false));
            return;
        }

        if (Mathf.Abs( carController.CurrentSpeed) > 3) { return; }
        if (manager == null)
        {
            open = CrossPlatformInputManager.GetButtonDown("Fire1");
        }
        else {
            open = CrossPlatformInputManager.GetButtonDown("Fire1") || manager.rightControllerTouchDown.grip;
        }
        
        //open = manager.rightControllerTouchDown.grip;
        if (open == true) {
            
            if (isOpening == false)
            {
                
                isOpening = true;
                
                StartCoroutine(OperateDoor(true));
                
            }
            else {
                isOpening = false;
                StartCoroutine(OperateDoor(false));
                
            }
           
        }
        
    }

    IEnumerator OperateDoor(bool up)
    {
        
        if (up == true)
        {   
            while (transform.localEulerAngles.x > openAngle || transform.localEulerAngles.x<=0)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - RotationGap, 0, 0);
                yield return 0;
                if (up != isOpening) {  yield break; }
            }
            yield break;
        }
        else {
            while (transform.localEulerAngles.x < 360 && transform.localEulerAngles.x >270 || transform.localEulerAngles.x == 0)
            {
            
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + RotationGap, 0, 0);
                yield return 0;
                if (up != isOpening) {  yield break; }
            }
            yield break;
        }
            
            
        
        //Debug.Log("This message appears after 3 seconds!");
    }
}
