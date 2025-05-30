using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player's transform
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothing factor

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Optional: make the camera look at the player
    }
}
