using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using John_Project;
public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text damageText;
    public TMP_Text damageText2;
    //public Image[] typeImages;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        nameText.text = cardData.cardName;
        damageText.text = $"{cardData.damageMin} - {cardData.damageMax}";
        damageText2.text = $"{cardData.damageMin} - {cardData.damageMax}";

    }

}
