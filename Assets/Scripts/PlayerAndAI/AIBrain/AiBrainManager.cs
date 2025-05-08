using Assets.Scripts.PlayerAndAI.AIBrain.StateModeAI;
using System.Collections.Generic;
using UnityEngine;


public class AiBrainManager : MonoBehaviour
{

    [SerializeField] private ManagerCostPlayedCardSystem costSystem;
    [SerializeField] private HandPlaceManager handSystem;
    [SerializeField] private DeckLibrary deck;

    private PoolsCardController poolCards;
    private PlayerBase bot;

    private ReferiController referiSystem;

    List<CardData> spells = new List<CardData>();
    List<CardData> creatures = new List<CardData>();




    protected IBotModeState currentModeBot;

    public ReferiController ReferiSystem {set => referiSystem = value; }

    public void setState(IBotModeState newState)
    {
        currentModeBot = newState; 
    }

    public void setBotMode()
    {

        if (currentModeBot != null)
        {
            currentModeBot.ExiteMode(this);
        }

        Debug.Log("Calculate choose Mode");
        setState(new ValueModeAI());
        currentModeBot.EnterMode(this);
    }

    public void setBrainData(PlayerBase player)
    {
        bot = player;
    }

    public void startTurn()
    {
        setBotMode();

    }

    public void endTurn()
    {
        currentModeBot.ExiteMode(this);
    }



    










    // turn AI

    public void updateHandCards()
    {
        updateListCreatures();
        updateListSpells();

        Debug.Log("знайшов карти в руці");
    }    

    public void updateListCreatures()
    {
        creatures = getHandCreature();
    }

    public void updateListSpells()
    {
        spells = getHandSpell();
    }    

    public bool hasCreaturesHand()
    {
        if (creatures.Count > 0)
        {
            Debug.Log("у руці є створіння");
            return true;
        }

        return false;

    }    

    public bool countCreaturesThanSpells()
    {
        if (creatures.Count > spells.Count)
        {
            Debug.Log("сторінь більше ніж заклять");
            return true;
        }

        return false;
    }



    public bool isPlaingSpellCreatureComboLogic()
    {

        int sumResult = 0;
        CardData spell = null;
        CardData creature = null;


        for (int i = 0; i < spells.Count; i++)
        {
            for (int j = 0; j < creatures.Count; j++)
            {
                int sumPower = spells[i].getPowerCard() + creatures[j].getPowerCard();

                if (sumPower > referiSystem.getPowerStatusPlayer())
                {
                    if (sumResult < sumPower)
                    {
                        sumResult = sumPower;
                        spell = spells[i];
                        creature = creatures[j];
                    }

                }

            }


        }


        if (sumResult != 0)
        {
            Debug.Log("розіграв комбу створіння та закляття");
            getHandCardManagerByData(spell).tryPlayCard();
            getHandCardManagerByData(creature).tryPlayCard();
            return true;
        }


        return false;

    }




    public void findPlaingSpell()
    {
        if (checkCostSlotSpell())
        {
            if (creatures.Count <= spells.Count)
            {
                CardManager spellCard = getHandCardManagerByData(getWeakleCard(spells));
                spellCard.tryPlayCard();
                Debug.Log("розіграв одне закляття");

            }
        }
 
    }


    public List<CardData> getCardsStrongerThanOpponent()
    {
        List<CardData> cardPowerFull = new List<CardData>();

        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i].getPowerCard() > referiSystem.getPowerStatusPlayer())
            {
                cardPowerFull.Add(creatures[i]);
            }
        }

        Debug.Log("шукаю сильних свторінь");

        return cardPowerFull;


    }
    // turn ai end
   





    // sort cards ai 

    public List<CardData> getListCreatures()
        { return creatures; }

    public List<CardData> getListSpells() 
        { return spells; }


    public List<CardData> getCardDataHand()
    {
        return poolCards.ConvertManagerCardsToCardsData(handSystem.getCardHand());
    }


    public List<CardData> getHandSpell()
    {
        return poolCards.getPoolSpell(getCardDataHand());
    }

    public List<CardData> getHandCreature()
    {
        return poolCards.GetPoolCreature(getCardDataHand());
    }


    public CardData getWeakleCard(List<CardData> cards)
    {
        Debug.Log("шукаю найслабшу карту з пулу підходящих карт");
        return poolCards.findLowPowerCard(cards);
    }



    // hand ai 
    public void createStartHand()
    {
        handSystem.createStartHand(bot, deck);
    }

    public CardManager getHandCardManagerByData(CardData card)
    {
        if (card != null)
        {
            return poolCards.FindCardManagerByData(handSystem.getCardHand(), card);
        }

        return null;
        
    }




    //deck AI manipulations

    public void createDeck()
    {
        poolCards = PoolsCardController.Instance;
        ReferiSystem = poolCards.gameManager.ReferiSystem;
        deck.createDeck();
        deck.shuffleDeck();

        Debug.Log("BOT deck Complete");

    }

    public void drawCardLogic()
    {
        CardData cardData = deck.DrawCard();

        if (cardData != null)
        {
            handSystem.addHandCards(cardData, bot);
            Debug.Log("взяв карту з колоди");
        }

    }

    public bool isDrawCardDeck()
    {
        return deck.checkDrawCard();
    }

    public bool checkCostSlotSpell()
    {
        return costSystem.getCurrentCostSlotSpell() > 0;
    }




}
