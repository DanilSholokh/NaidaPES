using System.Collections.Generic;
using UnityEngine;

// всі карти які можуть використовуватися в грі
public class GameCardsLibrary : MonoBehaviour
{

    [SerializeField] private List<CardData> cardsPool;

    private Dictionary<int, CardData> cardDictionary;



    private void Awake()
    {
        cardDictionary = new Dictionary<int, CardData>();

        foreach (var card in cardsPool)
        {
            if (!cardDictionary.ContainsKey(card.id))
            {
                cardDictionary.Add(card.id, card);
            }
            else
            {
                Debug.LogWarning("CardData with ID " + card.id + " already exists.");
            }
        }
    }

    public CardData getRandomCard()
    {
        int r_num = Random.Range(0, cardsPool.Count);

        return cardsPool[r_num];

    }

    public CardData findCard(int id) // получить карту по айди (инту)
    {
        if (cardDictionary.TryGetValue(id, out CardData card))
        {
            return card;
        }
        else
        {
            Debug.Log("!!! Not found card with id = " + id);
            return null;
        }
    }


    public List<CardData> findeListCards(List<int> cardsId) // переделать айди лист в кард лист
    {
        List<CardData> cards = new List<CardData>();

        for (int i = 0; i < cardsId.Count; i++)
        {
            cards.Add(findCard(cardsId[i]));
        }

        return cards;

    }


    public void getIdCardList(List<int> list) // получить список айди карт, нельзя сортировать
    {
        list.Clear();

        foreach (var card in cardsPool)
        {
            list.Add(card.id);
        }

    }

    
    public void getCardList(List<CardData> list) // get CARDS list
    {
        list.Clear();

        foreach (var card in cardsPool)
        {
            list.Add(card);
        }

    }


    public List<CardData> getListTypeCards(string cardType)
    {
        List<CardData> newList = new List<CardData>();

        for (int i = 0; i < cardsPool.Count; i++)
        {
            if (cardsPool[i].getCardType().ToString() == cardType)
            {
                newList.Add(cardsPool[i]);
            }
        }

        return newList;
    }


    public List<CardCreature> GetCreatureCards()
    {

        var newCardCreature = new List<CardCreature>();

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


    public List<CardSpell> GetSpellCards()
    {

        var newCardSpell = new List<CardSpell>();

        if (cardsPool != null)
        {
            foreach (var card in cardsPool)
            {
                if (card is CardSpell spell)
                {
                    newCardSpell.Add(spell);
                }
            }
        }

        return newCardSpell;

    }










    /// сейф скрипт -------------------------------
    public void buyCards(int idBuyCard)
    {
        for (int i = 0; i < cardsPool.Count; i++)
        {

            if (cardsPool[i].id == idBuyCard)
            {
                PlayerPrefs.SetInt("DeckLibrary " + idBuyCard, 1);
            }

        }


    }


    public void sellCards(int idSellCard)
    {
        for (int i = 0; i < cardsPool.Count; i++)
        {

            if (cardsPool[i].id == idSellCard)
            {
                PlayerPrefs.SetInt("DeckLibrary " + idSellCard, 0);
            }



        }
    }




}
