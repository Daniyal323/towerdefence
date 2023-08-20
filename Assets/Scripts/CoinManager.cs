using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int scorePerCoin = 5; // The score gained for each collected coin
    public int coinsForStar1 = 10; // Number of coins needed for 1 star
    public int coinsForStar2 = 20; // Number of coins needed for 2 stars
    public int coinsForStar3 = 30; // Number of coins needed for 3 stars

    private int score = 0; // Player's score
    [SerializeField] private int collectedCoins = 0; // Number of collected coins
    public TextMeshProUGUI ScoreTxt; // TextMeshPro for UI score display
    public TextMeshProUGUI LevelCompleteScoreTxt; // TextMeshPro for level complete screen score display
    public GameObject star1; // GameObject representing star 1
    public GameObject star2; // GameObject representing star 2
    public GameObject star3; // GameObject representing star 3

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coins"))
        {
            // Increment the score and collected coins
            score += scorePerCoin;
            collectedCoins++;

            // Deactivate the collected coin
            other.gameObject.SetActive(false);

            // Update the UI
            UpdateUI();

            // Log the current score
            Debug.Log("Collected coin! Current score: " + score);
        }
    }

    private void UpdateUI()
    {
        // Update the TextMeshPro text with the new score
        if (ScoreTxt != null)
        {
            ScoreTxt.text = score.ToString();
        }
    }

    public void UpdateLevelCompleteUI()
    {
        // Update the TextMeshPro text on the level complete screen
        if (LevelCompleteScoreTxt != null)
        {
            LevelCompleteScoreTxt.text =score.ToString();
        }

        // Determine the number of stars based on collected coins
        int stars = 0;
        if (collectedCoins >= coinsForStar1)
        {
            stars++;
            star1.SetActive(true); // Assuming star1 is an Image component GameObject
        }
        if (collectedCoins >= coinsForStar2)
        {
            stars++;
            star2.SetActive(true); // Assuming star2 is an Image component GameObject
        }
        if (collectedCoins >= coinsForStar3)
        {
            stars++;
            star3.SetActive(true); // Assuming star3 is an Image component GameObject
        }

        Debug.Log("Stars earned: " + stars);
    }

}
