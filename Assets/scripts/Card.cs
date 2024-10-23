using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace John_Project
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {


        public string cardName;

        public List<CardType> cardType;

        public int damageMin;

        public int damageMax;

        public int Cost;

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
}
