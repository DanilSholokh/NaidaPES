using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrainManager : MonoBehaviour
{

    [SerializeField] private ManagerCostPlayerSystem costSystem;
    [SerializeField] private HandPlaceManager handSystem;
    [SerializeField] private DeckLibrary deck;

    [SerializeField] private PoolsCardController poolCards;


    protected IBotModeState currentModeBot;

    public void setState(IBotModeState newState)
    {
        currentModeBot = newState; 
    }



    public void startTurn()
    {
        currentModeBot.EnterMode(this);
    }

    public void endTurn()
    {
        currentModeBot.ExiteMode(this);
    }







    public List<CardData> getCardHand()
    {
        return poolCards.listManagerCardConvertToCardData(handSystem.handCardsList);
    }

    public List<CardSpell> getSpell()
    {
        return poolCards.getPoolSpells(getCardHand());
    }

    public List<CardCreature> getCreature()
    {
        return poolCards.getPoolCreature(getCardHand());
    }










}
