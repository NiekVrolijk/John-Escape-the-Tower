using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Encountercontroller : MonoBehaviour
{
    public pointScript pointScript;

    public GameObject popupPanel;
    public GameObject textBox;
    public TextMeshProUGUI popupText;
    public Button closeButton;

    private List<string> randomEvent = new List<string> {
        "You come across a cheese mushroom filled room! You lose 50 Rations as you experience stamina loss.",
        "A trap triggers as you are engulfed in steaming hot cheese! You lose 100 Rations",
        "You encounter a treasure cheese filled with Gouda Cheese, a rare find indeed! You gain 100 rations.",
        "You fall asleep in stinky cheese, lose 25 rations.",
        "You find a dead skeleton with 50 rations on him.",
        "You find a dead cheese wolf with 75 rations.",
        "The room collapses and you lose 75 rations as you barely escape.",
        "A bag with molten cheese lies before you, you pick it up and you gain 50 rations.",
        "The tyromancer has pickpocketed you and has stolen 100 rations!",
        "",
        "",
        "",
        "",
    };
}
