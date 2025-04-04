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
    Vector3 vehicleLocalDirection;
    
    int giro = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        vehicleLocalDirection = Vector3.zero;
        forwardSpeed = Vector3.Dot(rb.velocity, transform.forward);
       
        if (forward == true)
        {
            vehicleLocalDirection = gameObject.transform.forward;
        }
        if (reverse == true)
        {
            vehicleLocalDirection = -gameObject.transform.forward;           
        }
        if (braking == true)
        {
            vehicleLocalDirection = transform.InverseTransformDirection(rb.velocity);
            if(vehicleLocalDirection == Vector3.forward)
            {
                rb.velocity -= transform.forward * brakeForce * Time.fixedDeltaTime;
            }

        }
        if (rb.velocity.magnitude <= maxSpeed) { rb.velocity += vehicleLocalDirection * acceleration * Time.fixedDeltaTime; }

        rb.AddTorque(0, turnForce*giro, 0);
    }
    void Update()
    {
        giro = 0;
        forward = Input.GetKey(KeyCode.W);
        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude > 0) { braking = true; }
        else { braking = false; }
        if (Input.GetKey(KeyCode.A)){giro = -1;}
        if (Input.GetKey(KeyCode.D)){giro = 1;}
        if (Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.A)) { giro = 0; }
        reverse = Input.GetKey(KeyCode.S);
        if (Input.GetKey(KeyCode.A)){giro -= 1;}
        if (Input.GetKey(KeyCode.D)){giro += 1;}
    }
}
