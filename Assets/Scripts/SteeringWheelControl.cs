using UnityEngine;
using System.Collections;
public class SteeringWheelControl : MonoBehaviour
{
    // VrCarUserControl on the Car
    public VrCarUserControl vrCarUserCtrl;
    // record the original local rotation
    private Quaternion origin;
    // Use this for initialization
    void Start()
    {
        origin = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate by degree from VrCarUserControl
        transform.localRotation = origin * Quaternion.Euler(0, 0, vrCarUserCtrl.degree);
    }
}