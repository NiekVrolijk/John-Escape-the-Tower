using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<Card> cardsForSale;  // List of cards available in the shop
    public Transform shopUIParent;    // Parent object in the UI where cards will be displayed
    public GameObject cardPrefab;      // Prefab for card UI display
    public int playerCurrency = 100;   // Example currency system, starts with 100 coins

    public Text currencyText;           // UI Text for displaying player's currency
    public DeckManager deckManager;     // Reference to the player's deck manager
    public HandManager handManager;     // Reference to the player's hand manager

    void Start()
    {
        UpdateCurrencyUI();
        PopulateShop();
    }

    // Displays available cards in the shop
    public void PopulateShop()
    {
        foreach (Card card in cardsForSale)
        {
            GameObject cardObject = Instantiate(cardPrefab, shopUIParent);
            CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>();
            cardDisplay.cardData = card;
            cardDisplay.cardImage.sprite = card.cardImage; // Assuming the card data includes an image
            Button buyButton = cardObject.GetComponent<Button>();

            buyButton.onClick.AddListener(() => TryBuyCard(card));
        }
    }

    // Tries to buy the card, checks if the player has enough currency
    public void TryBuyCard(Card card)
    {
        int cardPrice = GetCardPrice(card); // Assume each card has a price
        if (playerCurrency >= cardPrice)
        {
            playerCurrency -= cardPrice;
            deckManager.allCards.Add(card);  // Add the card to the player's deck
            handManager.AddCardToHand(card);  // Add the card to the player's hand
            UpdateCurrencyUI();
        }
        else
        {
            Debug.Log("Not enough currency to buy this card.");
        }
    }

    // Updates the UI to display the player's current currency
    private void UpdateCurrencyUI()
    {
        currencyText.text = "Currency: " + playerCurrency.ToString();
    }

    // Example function to get the price of a card
    private int GetCardPrice(Card card)
    {
        // You could set up a price based on card attributes (e.g., rarity or power)
        return 20; // For example, all cards cost 20 coins
    }
}
