using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using John_Project;

public class HandManager : MonoBehaviour
{
    public DeckManager deckManager;
    public GameObject cardPrefab;
    public Transform handTransform; //potition of the hand

    public float fanSpread = 7.5f;

    public float cardSpacing = -100f;

    public float verticalSpacing = 100f;

    public List<GameObject> cardsInHand = new List<GameObject>(); //list of the cards in the hand

    void Start()
    {
        /*AddCardToHand();
        AddCardToHand();
        AddCardToHand();
        AddCardToHand();*/
        
    }

    public void AddCardToHand(Card cardData)
    {
        //instantiate card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);
        //^this shit make the card... I think

        //put the card data in the instantiated card
        newCard.GetComponent<CardDisplay>().cardData = cardData;
        newCard.GetComponent<CardDisplay>(); //this puta all the data into the cards I don't think you'll need this but just incase you do this is were it happens
        newCard.GetComponent<BattleSystem>().cardData = cardData;
        newCard.GetComponent<BattleSystem>();
        UpdateHandVisuals();
    }
    private void Update()
    {
        //UpdateHandVisuals();
    }
    private void UpdateHandVisuals()
    {
        //visuals for were the cards are on the screen
        int cardCount = cardsInHand.Count;

        if (cardCount == 1 )
        {
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }
        for (int i = 0; i < cardCount; i++)
        {
            float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f));
            float normalizedPotition = (2f * i / (cardCount - 1) - 1f);
            float verticalOffset = verticalSpacing * (1  - normalizedPotition * normalizedPotition);

            //card potition
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
            
        }
    }
}
