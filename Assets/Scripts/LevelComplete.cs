using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Reference to the canvas showing level complete message
    public GameObject joystick;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if(other.gameObject.tag == "complete")
        {
            levelCompleteCanvas.SetActive(true);
            joystick.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}