using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Collider coinCollider;
    int randomIndex;
    [SerializeField] List<Transform> teleportSpots;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            TeleportToRandomSpot();
        }
    }

    void TeleportToRandomSpot()
    {
        randomIndex = Random.Range(0, teleportSpots.Count);
        transform.position = teleportSpots[randomIndex].position;
    }
}
