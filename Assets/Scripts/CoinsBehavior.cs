using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Collider coinCollider;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
