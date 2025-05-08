using Assets.Scripts.BattlefieldSystem;
using Assets.Scripts.CardPlace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// хендлер для карт менеджер
public class HandPlaceManager : MonoBehaviour
{

    public GameManager gameManager;

    private AnimHandCards animHand;


    public int maxHandCard = 8;
    public int sizeStartHand = 6;
    public List<CardManager> handCardsList = new List<CardManager>();

    private CreateCard createCard;


    private void Start()
    {
        createCard = new CreateCard();

        animHand = GetComponent<AnimHandCards>();
        animHand.HandPlace = this;

    }


    public List<CardManager> getCardHand()
    {
        return handCardsList; 
    }


    public void addHandCards(CardData card, PlayerBase playerBase)
    {

        if (handCardsList.Count >= maxHandCard)
        {
            removeHandCards(handCardsList[0]);
        }

        CardManager cardManager = createCard.CreateCardInstance(card, animHand.handRectTransform, playerBase);
        
        cardManager.setUILookBlockDetect();
        cardManager._gameManager = gameManager;

        handCardsList.Add(cardManager);

        cardManager._handPlaceCards = this;

        StartCoroutine(animHand.DelayedCalculatePlaceCreateCard());
    }


    public void removeHandCards(CardManager card)
    {
        // Animation delete card
        Destroy(card.gameObject);
        handCardsList.Remove(card);
        StartCoroutine(animHand.DelayedCalculatePlaceCreateCard());

    }


    public void createStartHand(PlayerBase player, DeckLibrary deck)
    {
        for (int i = 0; i < sizeStartHand; i++)
        {
            addHandCards(deck.getUpCard(), player);
        }
    }


}
