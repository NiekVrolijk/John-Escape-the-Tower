using John_Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_unit : JohnScript
{
    public string unitName;
    public int unitDamage;
    public int unitMaxhp;
    public int unitCurrenthp;

    private bool playerTurn = true;  // Boolean to track whose turn it is
    private int playerDamage = 1;    // Default damage (set to 1)

    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
        private void Update()
    {
        if (playerTurn)
        {
            // Wait for player to input attack damage by pressing keys 0-9
            Debug.Log("waiting for attack");
            DetectDamageInput();
        }
    }

    // Detect number key presses (0-9) to set playerDamage
    private void DetectDamageInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerDamage = 1;  // Even if 0 is pressed, set damage to at least 1
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerDamage = 2;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerDamage = 3;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerDamage = 4;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerDamage = 5;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerDamage = 6;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            playerDamage = 7;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            playerDamage = 8;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerDamage = 9;
            PlayerAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerDamage = 10;
            PlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        int attackIndex = playerDamage - 1; // Attack array is 0-based, so damage 1 corresponds to Attack[0]

        // Check if there are enough attacks left in the corresponding index
        if (JohnScript.Attack[attackIndex] > 0 && attackIndex != 0)
        {
            // Decrease the available attack count
            JohnScript.Attack[attackIndex]--;
            Debug.Log("Player attacks with " + playerDamage + " damage! Attacks remaining for this number: " + JohnScript.Attack[attackIndex]);

            // Proceed with attack
            TakeDamage(playerDamage);

            // Now it's the enemy's turn to attack
            playerTurn = false;
            StartCoroutine(EnemyTurn());
        } else if(attackIndex == 0)
        {
            Debug.Log("basic attack");
            // Proceed with attack
            TakeDamage(playerDamage);

            // Now it's the enemy's turn to attack
            playerTurn = false;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            Debug.Log("Not enough attacks left for damage value " + playerDamage + ". Try another number.");
        }
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);  // Small delay to simulate the enemy thinking or animating

        Debug.Log("Enemy attacks!");
        PlayerTakeDamage(unitDamage);  // Enemy attacks player

        playerTurn = true;
    }

    // Enemy takes damage
    public void TakeDamage(int dmg)
    {
        unitCurrenthp -= dmg;

        if (unitCurrenthp <= 0)
        {
            mainCamera.transform.position = new Vector3(0, 0, -10);
            JohnScript.rations += unitMaxhp * 50;
            Destroy(gameObject);
        }
    }

    // Player takes damage (using "rations" as health)
    public void PlayerTakeDamage(int dmg)
    {
        JohnScript.rations -= dmg;
    }
}
