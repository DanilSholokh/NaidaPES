using System.Collections.Generic;
using UnityEngine;

// карти які обрав ігрок, та які він буде використовувати в геймпелеї (колода)
public class DeckLibrary : MonoBehaviour
{

    [SerializeField] private List<CardData> deckCards = new List<CardData>();
    
    private PoolsCardController poolCards;
    private ControllerCostDeck costDeck;

    private void Start()
    {
        costDeck = GetComponent<ControllerCostDeck>();
    }




    public CardData DrawCard()
    {
        if (isDraw())
        {
            return getUpCard();
        }

        return null;

    }    

    public CardData getRandomCard()
    {
        return getCard(Random.Range(0, deckCards.Count));
    }

    public CardData getUpCard()
    {
        return getCard(0);
    }

    private CardData getCard(int idDeckCard)
    {
        CardData cardData = deckCards[idDeckCard];
        
        if (cardData != null)
        {
            deckCards.RemoveAt(idDeckCard);
        }
        
        return cardData;

    }




    // полная проверка на взятие карти с логикой отнятия стоимости
    public bool isDraw()
    {

        if (checkDrawCard())
        {
            logicDrawCardCost();
            return true;
        }
        

        return false;

    }

    // отнять стоимость взятие карти на єтом ходу
    public void logicDrawCardCost()
    {
        if (canDrawCardCost())
        {
            int tempDraw = costDeck.getCurrentDrawCount();
            tempDraw--;

            costDeck.setDrawCount(tempDraw);
        }
        
    }

    // проверка на возможность взять карту с колоди (по стоимости и карт в колоде)
    public bool checkDrawCard()
    {
        if (!IsDeckEmpty())
        {
            if (canDrawCardCost())
            {
                return true;
            }
        }

        return false;
    
    }
 
    // проверка на возможность взять карту на єтом ходу по стоимости
    private bool canDrawCardCost()
    {
        if (costDeck.getCurrentDrawCount() > 0)
        {
            return true;
        }

        return false;
    }

    public void resetCostToMaxDrawCard()
    {
        costDeck.setDrawCount(costDeck.getMaxDrawCount());
    }




    public void createDeck()
    {

        if (poolCards == null)
        {
            poolCards = PoolsCardController.Instance;
        }

        for (int i = 0; i < costDeck.getSizeDeck(); i++)
        {
            addCard(poolCards.getRandomGameCard());
        }

        Debug.Log("Number Cards in deck: " + deckCards.Count);
    
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

    public void addCard(CardData cardData)
    {
        int ran_num = Random.Range(0, deckCards.Count + 1);
        deckCards.Insert(ran_num, cardData);
    }




    public int countHasCard()
    {
        return deckCards.Count;
    }

    public bool IsDeckEmpty()
    {
        return deckCards.Count == 0;
    }

    public bool IsDeckFull()
    {
        return deckCards.Count >= costDeck.getSizeDeck();
    }  



}
