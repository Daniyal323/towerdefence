using UnityEngine;

public class CameraController: MonoBehaviour
{
    public Transform target;               // The target the camera will follow
    public Vector3 offset = new Vector3(0f, 2f, -5f);   // Camera offset from the target
    public float smoothSpeed = 0.125f;      // Speed at which the camera follows the target
    public float rotationSpeed = 2f;        // Speed at which the camera rotates around the target

    private Vector3 desiredPosition;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("No target assigned to the ThirdPersonCamera script.");
        }
        desiredPosition = target.position + offset;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Calculate the desired position of the camera based on the target's position and offset
        desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calculate the rotation angle based on the player's input
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the camera around the target
        Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        offset = rotation * offset;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
