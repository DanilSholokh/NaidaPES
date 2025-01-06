using System.Collections.Generic;
using UnityEngine;

// сортирує ро різним категоріям і робить пул картонок 
public class PoolsCardController : MonoBehaviour
{

    public static PoolsCardController Instance { get; private set; }

    private GameCardsLibrary gameLibrary;
    private PlayerCardLibrary playerLibrary;
    
    public DeckLibrary deckLibrary;
    public HandPlaceCards handPlaceCardsPlayer;
    public HandPlaceCards handPlaceCardsPlayerTwo;


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


    public CardData getRandomGameCard()
    {
        return gameLibrary.getRandomCard();
    }

    public CardData getRandomDeckCard()
    {
        return deckLibrary.getRandomCard();
    }
    
    public CardData getRandomPlayerCard()
    {
        return gameLibrary.findCard(playerLibrary.getRandomIdCard());
    }    

    public List<CardData> getPoolPlayerCards() // get all player cards in list<CardData>
    { 
        return gameLibrary.findeListCards(playerLibrary.getPlayerCards());
    }

    public List<CardData> getPoolTypeCards(string typeCard)
    {
        return gameLibrary.getListTypeCards(typeCard);
    }

    public List<CardCreature> getPoolCreature()
    {
        return gameLibrary.GetCreatureCards();
    }

    public List<CardSpell> getPoolSpells()
    {
        return gameLibrary.GetSpellCards();
    }

    public List<CardCreature> getPoolPowerCreaturesUp(int minPower)
    {

        List<CardCreature> creatures = getPoolCreature();

        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i].powerCard <= minPower)
            {
                creatures.RemoveAt(i);
            }
        }

        return creatures;
    
    }


    public List<CardCreature> getPoolPowerCreaturesDown(int maxPower)
    {

        List<CardCreature> creatures = getPoolCreature();

        for (int i = 0; i < creatures.Count; i++)
        {
            if (creatures[i].powerCard >= maxPower)
            {
                creatures.RemoveAt(i);
            }
        }

        return creatures;

    }



    public List<CardSpell> getPoolPowerSpellsUp(int minPower)
    {

        List<CardSpell> spells = getPoolSpells();

        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].powerUp <= minPower)
            {
                spells.RemoveAt(i);
            }
        }

        return spells;

    }


    public List<CardSpell> getPoolPowerSpellsDown(int maxPower)
    {

        List<CardSpell> spells = getPoolSpells();

        for (int i = 0; i < spells.Count; i++)
        {
            if (spells[i].powerUp >= maxPower)
            {
                spells.RemoveAt(i);
            }
        }

        return spells;

    }







}    
