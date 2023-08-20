using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Button firingButton;
    public GameObject joystick;
    public GameObject arrow;
    public GameObject[] weaponOptions; // An array of weapon options

    private int enemyCount;
    public GameObject selectedWeapon; // The currently selected weapon

    private void Start()
    {
        ShowWeaponOptions(); // Display weapon selection options at the start
        UpdateUI();
    }

    private void Update()
    {
        UpdateEnemyCount();
        UpdateUI();

        if (enemyCount == 0)
        {
            firingButton.gameObject.SetActive(false);
            joystick.SetActive(true);
            arrow.SetActive(true);
            if (selectedWeapon != null)
            {
                Destroy(selectedWeapon);
                selectedWeapon = null;
            }
        }
        else
        {
            firingButton.gameObject.SetActive(true);
            joystick.SetActive(false);
        }
    }

    private void ShowWeaponOptions()
    {
        foreach (GameObject weaponOption in weaponOptions)
        {
            weaponOption.SetActive(true);
        }
    }

    public void SelectWeapon(GameObject weapon)
    {
        foreach (GameObject weaponOption in weaponOptions)
        {
            weaponOption.SetActive(false);
        }

        selectedWeapon = Instantiate(weapon);
    }

    private void UpdateEnemyCount()
    {
        enemyCount = CountEnemiesWithTag("enemy");
    }

    private int CountEnemiesWithTag(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        return enemies.Length;
    }

    private void UpdateUI()
    {
        // Update any UI elements as needed
    }
}
