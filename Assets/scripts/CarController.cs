using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontleftwheelCollider;
    public WheelCollider frontrightwheelCollider;
    public WheelCollider backrightwheelCollider;
    public WheelCollider backleftwheelCollider;

    public Transform frontrightwheelTransform;
    public Transform frontleftwheelTransform;
    public Transform backrightwheelTransform;
    public Transform backleftwheelTransform;
    public Transform CarCenterOfMassTranform;
    public Rigidbody rigidbody;

    public float motorForce = 100f;
    public float steeringAngle = 30;
    public float brakeForce = 1000f;
    float verticalInput;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = CarCenterOfMassTranform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       motorforce();
        updateWheel();
        getInput();
        steering();
        applyBrake();
        powerSteering();
    }
    void getInput()
    {
        verticalInput=Input.GetAxis("Vertical");
        horizontalInput= Input.GetAxis("Horizontal");
    }
    void applyBrake()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            frontrightwheelCollider.brakeTorque = brakeForce;
            backrightwheelCollider.brakeTorque = brakeForce;
            frontleftwheelCollider.brakeTorque = brakeForce;
            backleftwheelCollider.brakeTorque = brakeForce;
            rigidbody.drag = 1;

        }
        else
        {
            frontrightwheelCollider.brakeTorque = 0f;
            backrightwheelCollider.brakeTorque = 0f;
            frontleftwheelCollider.brakeTorque = 0f;
            backleftwheelCollider.brakeTorque = 0f;
            rigidbody.drag = 0;
        }
       

    }
    void motorforce()
    {
        frontrightwheelCollider.motorTorque = motorForce * verticalInput;
        frontleftwheelCollider.motorTorque = motorForce * verticalInput;
        
    }
    void steering()
    {
        frontrightwheelCollider.steerAngle = 30f * horizontalInput;
        frontleftwheelCollider.steerAngle = 30f * horizontalInput ;

    }
    void powerSteering()
    {
        if(horizontalInput ==0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime);
        }
    }
    void updateWheel()
    {
        rotateWheel(frontrightwheelCollider, frontrightwheelTransform);
        rotateWheel(frontleftwheelCollider, frontleftwheelTransform);
        rotateWheel(backrightwheelCollider, backrightwheelTransform);
        rotateWheel(backleftwheelCollider, backleftwheelTransform);
    }
    void rotateWheel(WheelCollider wheelcollider , Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelcollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;

    }
}
