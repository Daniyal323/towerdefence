using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;  // Assign your main camera here
    public Transform gunPivot;  // Assign the empty GameObject here

    private void Update()
    {
        // Calculate the rotation needed to point the player and gun towards the camera's forward direction
        Quaternion targetRotation = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);

        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

        // Calculate the rotation needed to point the gun towards the camera's forward direction, but only in the horizontal plane
        Vector3 targetGunDirection = cameraTransform.forward;
        targetGunDirection.y = gunPivot.forward.y;  // Maintain the gun's local y-rotation

        Quaternion targetGunRotation = Quaternion.LookRotation(targetGunDirection, Vector3.up);

        // Apply the rotation to the gun pivot
        gunPivot.rotation = targetGunRotation;
    }
}
