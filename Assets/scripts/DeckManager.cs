using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using John_Project;

public class DeckManager : MonoBehaviour
{
   public List<Card> allCards = new List<Card>();

    private int currentIndex = 0;
    private void Start()
    {
        //Load assest from resources
        Card[] cards = Resources.LoadAll<Card>("Cards");
        
        //Add loaded Cards to card list
        allCards.AddRange(cards);
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        {
            return;
        }
        Card nextCard = allCards[3];
        handManager.AddCardToHand(nextCard);
        currentIndex = (currentIndex + 1) % allCards.Count;
    }
}
