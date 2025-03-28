using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float turnForce;
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
        rb.velocity += vehicleDirection * speed * Time.fixedDeltaTime;
        vehicleDirection = Vector3.zero;
        
        if (forward == true)
        {
            vehicleDirection = gameObject.transform.forward;
        }
        if (reverse == true)
        {
            vehicleDirection = -gameObject.transform.forward;           
        }

        rb.AddTorque(0, turnForce*giro, 0);
    }
    void Update()
    {
        giro = 0;
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        else
        {
            forward = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            reverse = true;
        }
        else
        {
            reverse = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            giro = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            giro = 1;
        }
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.D))
        {
            giro = 0;
        }
    }
}
/*
 * 
 * 
 * acelerar:
 *      pulsarla
 *      no pulsarla
 *      
 * giro:
 *      0: no pulsar na || pulsar ambas
 *      -1: pulsar izq
 *      1: pulsar der
 *      
 * 
 * 
 */