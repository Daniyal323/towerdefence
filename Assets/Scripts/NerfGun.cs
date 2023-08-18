using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class NerfGun : MonoBehaviour
{
    public GameObject flechettePrefab;
    public Transform shootPoint;
    public Vector3 flechetteRotation = new Vector3(0f, 190f, 0f);
    public float shootForce = 100f;

    // Reference to the button UI component
    public Button shootButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the button's click event
        shootButton.onClick.AddListener(Shoot);
    }

    void Shoot()
    {
        GameObject flechette = Instantiate(flechettePrefab, shootPoint.position, Quaternion.Euler(flechetteRotation));
        Rigidbody flechetteRb = flechette.GetComponent<Rigidbody>();

        if (flechetteRb != null)
        {
            Vector3 shootDirection = transform.forward;
            flechetteRb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("Flechette prefab is missing Rigidbody component.");
        }
    }
}