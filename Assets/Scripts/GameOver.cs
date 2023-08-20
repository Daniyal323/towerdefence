using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Reference to the canvas showing level complete message
    public GameObject joystick;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "Player")
        {
            levelCompleteCanvas.SetActive(true);
            joystick.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
