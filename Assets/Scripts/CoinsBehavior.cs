using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
    }
}
