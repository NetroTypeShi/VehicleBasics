using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Cámara extremadamente cercana: justo detrás y un poco arriba
    [SerializeField] private Vector3 offset = new Vector3(0f, 1.5f, -0.5f);
    [SerializeField] private float smoothTime = 0.001f; // Súper rápida
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime / smoothTime);
    }
}








