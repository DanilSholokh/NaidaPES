using System.Collections.Generic;
using UnityEngine;

// відповідає за створення та менеджмент панелі обираючих карт з будь якої точки скрипта
public abstract class SelectCardsCreator
{

    public Transform panelTreeCardPrefab;
    private Transform panelChooseCardPlace;

    private int maxCountCard;

    private List<CardManager> cardsTreeTableList;
    public CreateCard createCard;

    public PlayerBase playerBase;
    public int countCards;

    protected SelectCardsCreator(PlayerBase playerBase)
    {
        this.playerBase = playerBase;
    }

    public abstract void createPrefabPanel();
    public abstract void addCard(CardData card);


    public void initClass(int maxCountCard)
    {
        createCard = new CreateCard();
        cardsTreeTableList = new List<CardManager>();

        this.maxCountCard = maxCountCard;

        createSelectCardPrefab();

    }


    private void createSelectCardPrefab()
    {
        Transform panelTreeCard = loadSelectCardPrefab();
        panelTreeCardPrefab = Object.Instantiate(panelTreeCard, findPlace());

    }

    public virtual Transform loadSelectCardPrefab()
    {
        Transform panelPrefab = Resources.Load<Transform>("Prefab/PanelSelectCard");
        return panelPrefab; 
    
    }

    private Transform findPlace()
    {

        GameObject place = GameObject.FindWithTag("PlaceCreateTreeCard");

        if (place == null)
        {
            Debug.Log("Not Found Object with tag PlaceCreateTreeCard");
        }   

        return place.transform;

    }    


    public void createTreeCard()
    {
        сlearList();
        int i = 0;


        while (cardsTreeTableList.Count < maxCountCard)
        {
            i++;
            CardData cardData = getCardData();

            if (!hasCardInCardTableList(cardData))
            {
                CardManager cardManager = createCard.CreateCardInstance(cardData, panelTreeCardPrefab.GetChild(0).transform, playerBase);

                cardsTreeTableList.Add(cardManager);
                cardManager.Handler.setPanelTreeCard(this);

            }


            if (i >= 1000)
            {
                Debug.Log("crash");
                break;
            }


        }


    }

    public virtual CardData getCardData() // пул карт откуда будет братся карта 
    {
        CardData cardData = createCard.poolsCard.getRandomPlayerCard();
        return cardData;
    }

    private bool hasCardInCardTableList(CardData card)
    {
        for (int i = 0; i < cardsTreeTableList.Count; i++)
        {
            if (cardsTreeTableList[i].card == card)
            {
                return true; 
            }
        }
         
        return false;
    }


    private void сlearList()
    {
        if (cardsTreeTableList.Count > 0)
        {
            foreach (var card in cardsTreeTableList)
            {
                if (card != null)
                {
                    Object.Destroy(card.gameObject);
                }
            }

            cardsTreeTableList.Clear();

        }
    }



}
