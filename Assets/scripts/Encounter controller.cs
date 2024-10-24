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
            TriggerRandomEvent();
            visitedTiles.Add(tileID); 
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

    // Function to close the popup
    private void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}

