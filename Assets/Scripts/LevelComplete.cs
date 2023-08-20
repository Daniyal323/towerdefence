using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Reference to the canvas showing level complete message

    private bool levelCompleted = false;

    private void Start()
    {
        // Ensure the canvas starts as inactive
        if (levelCompleteCanvas != null)
        {
            levelCompleteCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!levelCompleted && other.CompareTag("complete"))
        {
            // Player collided with the "complete" object
            levelCompleted = true;

            // Show the level complete canvas
            if (levelCompleteCanvas != null)
            {
                levelCompleteCanvas.SetActive(true);
            }

            // Stop gameplay or any relevant actions here
            Time.timeScale = 0f; // Stops time (pause)
            // You might want to disable player controls or other scripts as needed
        }
    }
}
