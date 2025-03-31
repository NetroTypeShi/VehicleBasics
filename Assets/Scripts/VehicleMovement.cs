using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float acceleration;
    [SerializeField] float turnForce;
<<<<<<< HEAD
    [SerializeField] float brakeForce;
    [SerializeField] float maxSpeed;
    float forwardSpeed;
=======
    [SerializeField] float maxSpeed;
>>>>>>> 0b51531130caab5a78de2fe09dfa0dde94b75dc0
    bool forward = false;
    bool reverse = false;
    Vector3 vehicleDirection;
    
    int giro = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();  
    }
    private void FixedUpdate()
    {
        

        vehicleDirection = Vector3.zero;
<<<<<<< HEAD
        forwardSpeed = Vector3.Dot(rb.velocity, transform.forward);
=======
        
>>>>>>> 0b51531130caab5a78de2fe09dfa0dde94b75dc0
        if (forward == true)
        {
            vehicleDirection = gameObject.transform.forward;
        }
        if (reverse == true)
        {
            vehicleDirection = -gameObject.transform.forward;           
        }

        if (rb.velocity.magnitude <= maxSpeed) { rb.velocity += vehicleDirection * acceleration * Time.fixedDeltaTime; }

        rb.AddTorque(0, turnForce*giro, 0);
    }
    void Update()
    {
        giro = 0;
        forward = Input.GetKey(KeyCode.W);
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude > 0) {}
        if (Input.GetKey(KeyCode.A)){giro = -1;}
        if (Input.GetKey(KeyCode.D)){giro = 1;}
        if (Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.A)) { giro = 0; }
=======
        reverse = Input.GetKey(KeyCode.S);
        if (Input.GetKey(KeyCode.A)){giro -= 1;}
        if (Input.GetKey(KeyCode.D)){giro += 1;}
>>>>>>> 0b51531130caab5a78de2fe09dfa0dde94b75dc0
    }
}
