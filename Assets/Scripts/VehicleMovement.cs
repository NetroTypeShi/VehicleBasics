using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float acceleration;
    [SerializeField] float turnForce;
    [SerializeField] float brakeForce;
    [SerializeField] float handBrakeForce;
    [SerializeField] float maxSpeed;
    [SerializeField] ParticleSystem rightPartileSystem;
    [SerializeField] ParticleSystem leftPartileSystem;
    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;
    Vector3 localDirection;
    Vector3 accelerationDirection;
    int giro = 0;
    [SerializeField] bool braking;
    bool forward = false;
    bool reverse = false;
    [SerializeField] bool handBraking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        localDirection = transform.InverseTransformDirection(rb.velocity);

        accelerationDirection = Vector3.zero;

        if (forward)
        {
            rightPartileSystem.Play();
            leftPartileSystem.Play();
            if (localDirection.z < maxSpeed)
            {
                accelerationDirection = transform.forward;
            }
        }
        else 
        {
            rightPartileSystem.Stop();
            leftPartileSystem.Stop();
        }

        if (reverse)
        {
            if (localDirection.z > -maxSpeed)
            {
                accelerationDirection = -transform.forward;
            }
        }

        if (handBraking)
        {
            rb.velocity = rb.velocity * (1f - handBrakeForce * Time.fixedDeltaTime);

            rightTrail.emitting = true;
            leftTrail.emitting = true;

            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            leftTrail.emitting = false;
            rightTrail.emitting = false;
        }

        if (braking)
        {
            rb.velocity = rb.velocity * (1f - brakeForce * Time.fixedDeltaTime);
            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
            }
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
        localDirection = transform.InverseTransformDirection(rb.velocity);

        if (Input.GetKey(KeyCode.S))
        {
            if (localDirection.z > 0.1f)
            {
                braking = true;
                reverse = false;
            }
            else
            {
                braking = false;
                reverse = true;
            }
        }
        else
        {
            braking = false;
            reverse = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            handBraking = true;
        }
        else
        {
            handBraking = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            giro = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            giro = 1;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            giro = 0;
        }
    }
}



