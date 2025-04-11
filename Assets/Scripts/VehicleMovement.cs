using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float acceleration;
    [SerializeField] float turnForce;
    [SerializeField] float brakeForce;
    [SerializeField] float maxSpeed;
    Vector3 localDirection;
    Vector3 accelerationDirection;
    int giro = 0;
    
    // Variables de control
    bool braking;
    bool forward = false;
    bool reverse = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // Convertir la velocidad mundial a local para evaluar en la dirección z
        localDirection = transform.InverseTransformDirection(rb.velocity);

        // Reiniciar la dirección de aceleración
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
            // Reducir la velocidad suavemente sin invertir la dirección
            rb.velocity = rb.velocity * (1f - brakeForce * Time.fixedDeltaTime);

            // Cuando la velocidad es muy baja, se anula para evitar movimientos residuales
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

        // Calcular la velocidad en el espacio local para determinar la dirección de movimiento
        localDirection = transform.InverseTransformDirection(rb.velocity);

        if (Input.GetKey(KeyCode.S))
        {
            // Si se mueve hacia adelante (componente z mayor que un umbral), se aplica el freno
            if (localDirection.z > 0.1f)
            {
                braking = true;
                reverse = false;
            }
            // Si ya está detenido o se mueve en reversa, se activa la marcha atrás
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



