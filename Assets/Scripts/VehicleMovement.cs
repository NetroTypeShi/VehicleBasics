using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float forceDirection;
    bool forward = false;
    bool reverse = false;
    Vector3 vehicleDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();  
    }
    private void FixedUpdate()
    {
        rb.velocity += vehicleDirection * speed * Time.fixedDeltaTime;
        vehicleDirection = Vector3.zero;
        rb.AddTorque(0, forceDirection, 0);
        if (forward == true)
        {
            vehicleDirection = Vector3.forward;
        }
        if (reverse == true)
        {
            vehicleDirection = Vector3.back;
        }
    }
    void Update()
    {
        forceDirection = 0;
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
            forceDirection = 300;
        }
        if (Input.GetKey(KeyCode.D))
        {
            forceDirection = -300;
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
 *      no pulsar na || pulsar ambas
 *      pulsar izq
 *      pulsar der
 *      
 * 
 * 
 */