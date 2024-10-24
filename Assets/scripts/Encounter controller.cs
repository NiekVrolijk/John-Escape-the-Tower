using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Encountercontroller : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI popupText;
    public Button closeButton;

    public GameObject mainCamera;

    public GameObject EnemyBattleStation;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;

    private List<string> randomEvents = new List<string> {
        "You come across a cheese mushroom filled room! You lose 50 Rations as you experience stamina loss.",
        "A trap triggers as you are engulfed in steaming hot cheese! You lose 100 Rations",
        "You encounter a treasure cheese filled with Gouda Cheese, a rare find indeed! You gain 100 rations.",
        "You fall asleep in stinky cheese, lose 25 rations.",
        "You find a dead skeleton gain 50 rations.",
        "You find a dead cheese wolf gain 75 rations.",
        "The room collapses and you lose 75 rations as you barely escape.",
        "A bag with molten cheese lies before you, you pick it up and you gain 50 rations.",
        "The tyromancer has pickpocketed you, lose 100 Rations!",
    };


    private HashSet<int> visitedTiles = new HashSet<int>();

    void Start()
    {
        popupPanel.SetActive(false);
        closeButton.onClick.AddListener(ClosePopup);
    }

    public void OnEnterTile(int tileID)
    {
        // Check if the tile has already been visited
        if (!visitedTiles.Contains(tileID))
        {
            visitedTiles.Add(tileID);
            int eventOrEncounter = Random.Range(0, 2);
            if (eventOrEncounter == 0)
            {
                TriggerRandomEvent();
            } else if (eventOrEncounter == 1)
            {
                TriggerRandomEncounter();
            }
        }
    }
    
    private void TriggerRandomEvent()
    {
        int randomIndex = Random.Range(0, randomEvents.Count);
        string selectedEvent = randomEvents[randomIndex];
        popupText.text = selectedEvent;
        popupPanel.SetActive(true);

        if (selectedEvent.Contains("lose 50 Rations")) JohnScript.UpdateRations(-50);
        else if (selectedEvent.Contains("lose 100 Rations")) JohnScript.UpdateRations(-100);
        else if (selectedEvent.Contains("gain 100 rations")) JohnScript.UpdateRations(100);
        else if (selectedEvent.Contains("lose 25 rations")) JohnScript.UpdateRations(-25);
        else if (selectedEvent.Contains("gain 50 rations")) JohnScript.UpdateRations(50);
        else if (selectedEvent.Contains("lose 75 rations")) JohnScript.UpdateRations(-75);
        else if (selectedEvent.Contains("gain 75 rations")) JohnScript.UpdateRations(75);
    }
    private void TriggerRandomEncounter()
    {
        int rdEnemy = Random.Range(0, 3);

        popupText.text = "An enemy attacks you";
        popupPanel.SetActive(true);
        mainCamera.transform.position = new Vector3(40, 0, -10);
        switch (rdEnemy)
        {
            case 0:
                GameObject enemyGO1 = Instantiate(enemyPrefab1, EnemyBattleStation.transform);
                break;
            case 1:
                GameObject enemyGO2 = Instantiate(enemyPrefab2, EnemyBattleStation.transform);
                break;
            case 2:
                GameObject enemyGO3 = Instantiate(enemyPrefab3, EnemyBattleStation.transform);
                break;
        }
            
    }

    // Function to close the popup
    private void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}

