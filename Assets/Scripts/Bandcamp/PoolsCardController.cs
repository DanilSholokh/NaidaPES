using System.Collections.Generic;
using UnityEngine;

// сортирує ро різним категоріям і робить пул картонок 
public class PoolsCardController : MonoBehaviour
{

    public static PoolsCardController Instance { get; private set; }

    private GameCardsLibrary gameLibrary;
    private PlayerCardLibrary playerLibrary;
    
    public DeckLibrary deckLibrary;
    public DeckLibrary botDeckLibrary; 

    public HandPlaceManager handPlacePlayer;
    public HandPlaceManager handPlaceAI;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        gameLibrary = GetComponent<GameCardsLibrary>(); 
        playerLibrary = GetComponent<PlayerCardLibrary>();

    }


    public List<CardData> listManagerCardConvertToCardData(List<CardManager> cards)
    {
        List<CardData> cardsData = new List<CardData>();

        for (int i = 0; i > cards.Count; i++)
        {
            cardsData.Add(cards[i].card);
        }

        return cardsData;
    }


    public CardData getRandomGameCard()
    {
        return gameLibrary.getRandomCard();
    }

    public CardData getRandomDeckCardHuman()
    {
        return deckLibrary.getRandomCard();
    }

    public CardData getRandomDeckCardAI()
    {
        return botDeckLibrary.getRandomCard();
    }

    public CardData getRandomPlayerCard()
    {
        return gameLibrary.findCard(playerLibrary.getRandomIdCard());
    }    

    public List<CardData> getPoolPlayerCards() // get all player cards in list<CardData>
    { 
        return gameLibrary.findListCards(playerLibrary.getPlayerCards());
    }

    public List<CardData> getPoolTypeCards(string typeCard)
    {
        return gameLibrary.getListTypeCards(typeCard);
    }

    public List<CardSpell> getPoolAllSpells()
    {
        return getPoolSpells(gameLibrary.getCardList());
    }

    public List<CardCreature> getPoolPowerCreaturesUp(int minPower, List<CardData> cards)
    {

        List<CardCreature> creatures = getPoolCreature(cards);

        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i].getPowerCard() <= minPower)
            {
                creatures.RemoveAt(i);
            }
        }

        return creatures;
    
    }


    public List<CardCreature> getPoolPowerCreaturesDown(int maxPower, List<CardData> cards)
    {

        List<CardCreature> creatures = getPoolCreature(cards);

        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i].getPowerCard() >= maxPower)
            {
                creatures.RemoveAt(i);
            }
        }

        return creatures;

    }



    public List<CardSpell> getPoolPowerSpellsUp(int minPower, List<CardData> cards)
    {

        List<CardSpell> spells = getPoolSpells(cards);

        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].getPowerCard() <= minPower)
            {
                spells.RemoveAt(i);
            }
        }

        return spells;

    }


    public List<CardSpell> getPoolPowerSpellsDown(int maxPower, List<CardData> cards)
    {

        List<CardSpell> spells = getPoolSpells(cards);

        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].getPowerCard() >= maxPower)
            {
                spells.RemoveAt(i);
            }
        }

        return spells;

    }

    public List<CardCreature> getPoolCreature(List<CardData> cardsPool)
    {

        List<CardCreature> newCardCreature = new List<CardCreature>();

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


    public List<CardSpell> getPoolSpells(List<CardData> cards)
    {

        List<CardSpell> newCardSpell = new List<CardSpell>();

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



}    
