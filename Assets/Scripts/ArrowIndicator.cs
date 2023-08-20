using UnityEngine;

public class ArrowIndicator: MonoBehaviour
{
    [SerializeField] private Transform target;
    private void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
}
