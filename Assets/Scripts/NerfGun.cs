using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NerfGun : MonoBehaviour
{
    public GameObject flechettePrefab;
    public Transform shootPoint;
    public Vector3 flechetteRotation = new Vector3(0f, 190f, 0f);
    public float shootForce = 100f;

    public Button shootButton;

    private List<Transform> enemies; // List of enemy transforms
    private int currentEnemyIndex = 0; // Index of the currently targeted enemy

    void Start()
    {
        shootButton.onClick.AddListener(Shoot);

        // Populate the list of enemies (you could do this dynamically based on enemy tags or layers)
        enemies = new List<Transform>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemies.Add(enemy.transform);
        }
    }

    void Update()
    {
        if (enemies.Count == 0)
        {
            return;
        }

        // Calculate the direction to the current targeted enemy
        Vector3 targetDirection = enemies[currentEnemyIndex].position - transform.position;
        targetDirection.y = 0f; // Ignore vertical component for rotation
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void Shoot()
    {
        if (enemies.Count == 0)
        {
            return;
        }

        GameObject flechette = Instantiate(flechettePrefab, shootPoint.position, Quaternion.Euler(flechetteRotation));
        Rigidbody flechetteRb = flechette.GetComponent<Rigidbody>();

        if (flechetteRb != null)
        {
            Vector3 shootDirection = transform.forward;
            flechetteRb.AddForce(shootDirection * shootForce, ForceMode.Impulse);

            // Increment the enemy index for the next shot
            currentEnemyIndex = (currentEnemyIndex + 1) % enemies.Count;
        }
        else
        {
            Debug.LogWarning("Flechette prefab is missing Rigidbody component.");
        }
    }
}
