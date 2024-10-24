using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JohnScript : MonoBehaviour
{
    public static int rations;
    public static int johnLocation = 0;

    public TextMeshProUGUI rationsText; // Reference to the UI TextMeshProUGUI component

    public static int[] Attack = new int[10];
    public TMPro.TMP_Text[] AttackAmount = new TMPro.TMP_Text[9]; // Only showing amounts for Attack[1] to Attack[9]

    // Start is called before the first frame update
    void Start()
    {
        // Initialize attack counts (for demonstration, all start at 1)
        for (int i = 0; i < Attack.Length; i++)
        {
            Attack[i] = 1;
        }
        rations = 1000;
        johnLocation = 0;
        UpdateRationsDisplay();
        UpdateAttackAmounts();  // Call this method to update the attack amounts at start
    }

    public static void UpdateRations(int amount)
    {
        rations += amount;
        // Ensure rations don't drop below zero
        rations = Mathf.Max(0, rations);
    }

    void Update()
    {
        UpdateRationsDisplay();
        UpdateAttackAmounts(); // Continuously update the displayed attack amounts

        if (rations <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }

        if (johnLocation == 19)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    // Method to update the rations display
    private void UpdateRationsDisplay()
    {
        if (rationsText != null)
        {
            rationsText.text = "Rations: " + rations.ToString();
        }
    }

    // Method to update the attack amounts displayed in the TMP texts
    private void UpdateAttackAmounts()
    {
        // Loop through Attack[1] to Attack[9], updating the TMP texts (ignoring Attack[0])
        for (int i = 1; i < Attack.Length; i++)
        {
            // Ensure the corresponding TMP_Text exists in the array (since AttackAmount is 0-based, use i-1)
            if (AttackAmount[i - 1] != null)
            {
                AttackAmount[i].text = Attack[i].ToString();
            }
        }
    }
}
