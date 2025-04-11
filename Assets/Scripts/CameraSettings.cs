using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Offset relativo al coche: (X, Y, Z)
    // Por ejemplo, (0, 3, -4) ubica la cámara 3 unidades arriba y 4 unidades detrás.
    [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -4f);
    [SerializeField] private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime / smoothTime);
    }
}





