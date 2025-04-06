using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCards : MonoBehaviour
{


    private int maxPowerCard = 1000000;
    private int minPowerCard = 0;


    public CardData getRandomCard(List<CardData> cards)
    {
        int r_num = Random.Range(0, cards.Count);

        return cards[r_num];

    }

    public List<CardData> getListTypeCards(List<CardData> cards, string cardType)
    {
        List<CardData> newList = new List<CardData>();

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].getCardType().ToString() == cardType)
            {
                newList.Add(cards[i]);
            }
        }

        return newList;
    }

    public List<CardData> sortBetweenPowerList(List<CardData> cards, int minPower, int maxPower)
    {

        List<CardData> newCardData = new List<CardData>();

        for (int i = 0; i < cards.Count; i++)
        {
            int tempPower = cards[i].getPowerCard();

            if (tempPower >= minPower)
            {
                if (tempPower <= maxPower)
                {
                    newCardData.Add(cards[i]);
                }
            }
        }

        return newCardData;

    }


    public List<CardData> getPoolPowerUp(List<CardData> cards, int minPower)
    {
        return sortBetweenPowerList(cards, minPower, maxPowerCard);
    }


    public List<CardData> getPoolPowerDown(List<CardData> cards, int maxPower)
    {
        return sortBetweenPowerList(cards, minPowerCard, maxPower);
    }


    public List<CardData> getPoolCreature(List<CardData> cardsPool)
    {

        List<CardData> newCardCreature = new List<CardData>();

        if (cardsPool != null)
        {
            foreach (var card in cardsPool)
            {
                if (card is CardCreature creature)
                {
                    newCardCreature.Add(creature);
                }
            }
        }

        return newCardCreature;

    }


    public List<CardData> getPoolSpells(List<CardData> cards)
    {

        List<CardData> newCardSpell = new List<CardData>();

        if (cards != null)
        {
            foreach (var card in cards)
            {
                if (card is CardSpell spell)
                {
                    newCardSpell.Add(spell);
                }
            }
        }

        return newCardSpell;

    }

    public CardData findLowPowerCard(List<CardData> cards)
    {
        CardData tempCards = cards[0];

        for (int i = 1; i < cards.Count; i++)
        {
            if (tempCards.getPowerCard() > cards[i].getPowerCard())
            {
                tempCards = cards[i];
            }
        }

        return tempCards;

    }    

        





}
