using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using John_Project;

public class DeckManager : MonoBehaviour
{
   public List<Card> allCards = new List<Card>(); //this one or the commment below this on is the one that gathers all the card data. honestly I have no clue which one it is

    private int currentIndex = 0;
    private void Start()
    {
        //Load assest from resources
        Card[] cards = Resources.LoadAll<Card>("Cards"); //this is the other one that I don't know if its gathering the card data. maybe you need both idk
        
        //Add loaded Cards to card list
        allCards.AddRange(cards);
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0)
        {
            return;
        }
        Card nextCard = allCards[3]; //ok so this function adds the 4rd card in the list (cause it starts counting from 0) because of the 3 so changing it to 0 or something would change it to that card on the list
        handManager.AddCardToHand(nextCard); //this is what adds the card to your hand
        currentIndex = (currentIndex + 1) % allCards.Count; //useless
    }
}
