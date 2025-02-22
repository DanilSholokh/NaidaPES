using Assets.Scripts.PlayerAndAI.AIBrain.StateModeAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AiBrainManager : MonoBehaviour
{

    [SerializeField] private ManagerCostPlayerSystem costSystem;
    [SerializeField] private HandPlaceManager handSystem;
    [SerializeField] private DeckLibrary deck;

    private PoolsCardController poolCards;

    public List<CardSpell> spells = new List<CardSpell>();
    public List<CardCreature> creatures = new List<CardCreature>();

    protected IBotModeState currentModeBot;

    public void setState(IBotModeState newState)
    {
        currentModeBot = newState; 
    }

    public void startTurn()
    {
        setBotMode();
        currentModeBot.EnterMode(this);
    }

    public void endTurn()
    {
        currentModeBot.ExiteMode(this);
    }





    public void setBotMode()
    {
        //Calculate choose Mode
        setState(new ValueModeAI());
    }

    public void initBotData()
    {
        poolCards = PoolsCardController.Instance;


        

        spells = getSpell();
        creatures = getCreature();

    }


    public void createDeck()
    {

        deck.createDeck();
        Debug.Log("BOT deck Complete");

    }


    public void createStartHand(PlayerBase player)
    {
        handSystem.createStartHand(player, deck);
    }

    public void drawCard(PlayerBase player)
    {
        handSystem.addHandCards(deck.getUpCard(), player);
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
