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

    // Start is called before the first frame update
    void Start()
    {
        rations = 1000;
        johnLocation = 0;
        UpdateRationsDisplay();
    }

    public static void UpdateRations(int amount)
    {
        rations += amount;
        // You may want to ensure rations don't drop below zero
        rations = Mathf.Max(0, rations);

    }

    void Update()
    {
        UpdateRationsDisplay();

        {
            if (rations <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
            if (johnLocation == 19)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    private void UpdateRationsDisplay()
    {
        if (rationsText != null)
        {
            rationsText.text = "Rations: " + rations.ToString();
        }
    }
}
