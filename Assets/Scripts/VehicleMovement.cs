using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float acceleration;
    [SerializeField] float turnForce;
    [SerializeField] float brakeForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float breakingForce;
    float forwardSpeed;
    bool braking;
    bool forward = false;
    bool reverse = false;
    Vector3 localDirection;
    Vector3 accelerationDirection;
    int giro = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }
    private void FixedUpdate()
    {
        localDirection = transform.InverseTransformDirection(rb.velocity);

        accelerationDirection = Vector3.zero;

        if (forward)
        {
            if (localDirection.z < maxSpeed)
            {
                accelerationDirection = transform.forward;
            }
        }

        if (reverse)
        {
            if (localDirection.z > -maxSpeed)
            {
                accelerationDirection = -transform.forward;
            }
        }

        if (braking)
        {
            rb.velocity -= transform.forward * brakeForce * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity += accelerationDirection * acceleration * Time.fixedDeltaTime;
        }

        rb.AddTorque(0, turnForce * giro, 0);
    }

    void Update()
    {
        giro = 0;
        forward = Input.GetKey(KeyCode.W);
        reverse = Input.GetKey(KeyCode.S);

        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude > 0) { braking = true; }
        else { braking = false; }
        if (Input.GetKey(KeyCode.A)){giro = -1;}
        if (Input.GetKey(KeyCode.D)){giro = 1;}
        if (Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.A)) { giro = 0; }
    }
} // p5js plugins unity  

