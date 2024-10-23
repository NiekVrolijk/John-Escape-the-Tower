using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayshop : MonoBehaviour
{
    public Card cardData; // Reference to the card data
    public Image cardImage; // Image component to display the card image
    public Text cardNameText; // Text component to display the card name

    void Start()
    {
        UpdateCardDisplay();
    }

    // Method to update the display with card data
    public void UpdateCardDisplay()
    {
        if (cardData != null)
        {
            cardImage.sprite = cardData.cardImage; // Set the card image
            cardNameText.text = cardData.cardName; // Set the card name
        }
    }
}
