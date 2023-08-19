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
    public float switchTargetInterval = 3f; // Time interval to switch targets

    public Button shootButton;

    private List<Transform> enemies; // List of enemy transforms
    private int currentEnemyIndex = 0; // Index of the currently targeted enemy
    private float switchTargetTimer = 0f;

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

        // Switch to the next target after the timer interval
        switchTargetTimer += Time.deltaTime;
        if (switchTargetTimer >= switchTargetInterval)
        {
            switchTargetTimer = 0f;
            currentEnemyIndex = (currentEnemyIndex + 1) % enemies.Count;
        }

        // Aim at the current targeted enemy
        Transform currentEnemy = enemies[currentEnemyIndex];
        Vector3 targetDirection = currentEnemy.position - shootPoint.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        shootPoint.rotation = Quaternion.Slerp(shootPoint.rotation, targetRotation, Time.deltaTime * 5f);
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
            Vector3 shootDirection = shootPoint.forward; // Use the shootPoint's forward direction
            flechetteRb.AddForce(shootDirection * shootForce, ForceMode.Impulse);

            // Move to the next enemy
            currentEnemyIndex = (currentEnemyIndex + 1) % enemies.Count;
        }
        else
        {
            Debug.LogWarning("Flechette prefab is missing Rigidbody component.");
        }
    }
}
