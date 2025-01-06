using System.Collections.Generic;
using UnityEngine;

// карти які обрав ігрок, та які він буде використовувати в геймпелеї (колода)
public class DeckLibrary : MonoBehaviour
{

    [SerializeField] private List<CardData> deckCards = new List<CardData>();
    [SerializeField] private int startSizeDeck = 20;


    private bool IsDeckEmpty()
    {
        return deckCards.Count > 0;
    }   
    
    public bool IsDeckFull()
    {
        return deckCards.Count >= startSizeDeck;
    }

    public void addCard(CardData cardData)
    {
        int ran_num = Random.Range(0, deckCards.Count + 1);
        deckCards.Insert(ran_num, cardData);
    }

    public int countHasCard()
    {
        return deckCards.Count; 
    }


    public void shuffleDeck()
    {
        for (int i = deckCards.Count - 1; i > 0; i--)
        {
            int ran_num = Random.Range(0, i + 1);
            CardData temp = deckCards[i];
            deckCards[i] = deckCards[ran_num];
            deckCards[ran_num] = temp;

        }
    }

    private void removeCard(CardData cardData)
    {  
        deckCards.Remove(cardData);
    }

    private void removeList()
    {
        deckCards.Clear();
    }

    public CardData getRandomCard()
    {

        int rand = Random.Range(0, deckCards.Count);

        CardData cardData = deckCards[rand];
        removeCard(cardData);

        return cardData;


    }

    public CardData getUpCard()
    {
        if (IsDeckEmpty())
        {
            CardData cardData = deckCards[0];
            deckCards.RemoveAt(0);

            return cardData;
        }

        Debug.Log("deck is Empty");
        return null;

    }


}
