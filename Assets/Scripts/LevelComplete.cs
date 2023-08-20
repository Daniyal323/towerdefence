using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Reference to the canvas showing level complete message
    public GameObject joystick;
    CoinManager cn;

    private void Start()
    {
        cn = GetComponent<CoinManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if(other.gameObject.tag == "complete")
        {
            levelCompleteCanvas.SetActive(true);
            joystick.SetActive(false);
            cn.UpdateLevelCompleteUI();
            Time.timeScale = 0f;

        }
    }
}
