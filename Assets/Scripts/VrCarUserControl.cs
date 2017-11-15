using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
[RequireComponent(typeof(CarController))]
public class VrCarUserControl : MonoBehaviour
{
    // we get all controller information from [ControllerManager]
    public ControllerManager manager;
    // the point we will use to define where the plane of steering wheel is
    public Transform originalPoint;
    public Transform xPoint;
    public Transform yPoint;
    public Transform zPoint;
    // we will use it to control our car, don't care about this class
    private CarController m_Car;
    // the data we will calculate for car moving simulation
    private Vector3 xVector, yVector, zVector;
    private Vector3 leftFootPoint, rightFootPoint;
    private Vector3 steeringWheelVector;
    private float leftFactor, rightFactor;

    private int controlMode=0;
    private int controlModeNum = 2;

    public float degree;
    public float h, v;
    // the function will be used to calculate the factor
    private float Factor(Vector3 _originalPoint, Vector3 _point, Vector3 _zVector)
    {
        float _zVectorLengthSqr = _zVector.magnitude * _zVector.magnitude;
        float _xPart = _zVector.x * (_originalPoint.x - _point.x);
        float _yPart = _zVector.y * (_originalPoint.y - _point.y);
        float _zPart = _zVector.z * (_originalPoint.z - _point.z);
        return (_xPart + _yPart + _zPart) / _zVectorLengthSqr;
    }
    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }
    private void Update()
    {
        // must make sure these institutes are not null
        if (manager == null || originalPoint == null || xPoint == null || yPoint == null || zPoint == null)
        {
            return;
        }
        
        if (manager.rightControllerTouchDown.applicationMenu || manager.rightControllerTouchDown.applicationMenu) {
            controlMode = (controlMode + 1) % controlModeNum;
        }
        xVector = xPoint.position - originalPoint.position;
        yVector = yPoint.position - originalPoint.position;
        zVector = zPoint.position - originalPoint.position;
        leftFactor = Factor(originalPoint.position, manager.leftControllerPosition, zVector);
        rightFactor = Factor(originalPoint.position, manager.rightControllerPosition, zVector);

        if (controlMode == 0)
        {
            // we use trigger to calculate the speed of car, AKA keyboard [W][S]
            v = manager.rightTriggerAxis.x - manager.leftTriggerAxis.x;

            // we use transforms of left and right controllers to calculate the orientation of car, AKA keyboard [A][D]
            leftFootPoint = manager.leftControllerPosition + leftFactor * zVector;
            rightFootPoint = manager.rightControllerPosition + rightFactor * zVector;
            steeringWheelVector = rightFootPoint - leftFootPoint;
            degree = Vector3.Angle(steeringWheelVector, yVector);
            if (degree > 90)
            {
                degree = 90;
            }
            if (Vector3.Angle(steeringWheelVector, xVector) < 90)
            {
                degree = -degree;
            }
            h = degree / 90;
        }
        else if (controlMode == 1)
        {
            v = manager.leftTouchpadAxis.y;
            h = manager.rightTouchpadAxis.x;
            degree = h * 90;
        }
        
        
        
        // move the car
        m_Car.Move(h, v, v, 0f);
    }

    void OnCollisionEnter(Collision other)
    {
        manager.VibrateBoth();
        Debug.Log("collision!");
    }
}