using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
   

    public string cardName;

    public List<CardType> cardType;

    public int health;

    public int damageMin;

    public int damageMax;

    public List<DamageType> damageType;

    public enum CardType 
    {
        Default,
        Spell,
    }

    public enum DamageType
    {
        Melee,
        Ranged,
    }

}