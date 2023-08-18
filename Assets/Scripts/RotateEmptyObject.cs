using UnityEngine;

public class RotateEmptyObject : MonoBehaviour
{
    public float rotationSpeed = -32.51f;

    void Update()
    {
        // Rotate the empty GameObject continuously
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
