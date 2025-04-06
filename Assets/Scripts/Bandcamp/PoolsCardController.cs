using System.Collections.Generic;
using UnityEngine;

// сортирує ро різним категоріям і робить пул картонок 
public class PoolsCardController : MonoBehaviour
{

    public static PoolsCardController Instance { get; private set; }

    private SortCards sort;
    public  GameManager gameManager;

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
        

        sort = GetComponent<SortCards>();
        gameLibrary = GetComponent<GameCardsLibrary>(); 
        playerLibrary = GetComponent<PlayerCardLibrary>();


    }

    private void Start()
    {
        //Instance = this;
        handPlaceAI.gameManager = gameManager;
        handPlacePlayer.gameManager = gameManager;

    }


    public List<CardData> ConvertManagerCardsToCardsData(List<CardManager> cards)
    {
        List<CardData> cardsData = new List<CardData>();

        for (int i = 0; i < cards.Count; i++)
        {
            cardsData.Add(cards[i].card);
        }

        return cardsData;

    }

    public CardManager FindCardManagerByData(List<CardManager> cards, CardData data)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if(cards[i].card.getId() == data.id)
            {
                return cards[i];
            }
        }


        return null;

    }


    public CardData FindCardPowerfullThan(List<CardData> cards, int minPower)
    {
        return sort.findLowPowerCard(sort.getPoolPowerUp(cards, minPower));
    }

    public CardData FindCardWeakerThan(List<CardData> cards, int maxPower)
    {
        return sort.findLowPowerCard(sort.getPoolPowerDown(cards, maxPower));
    }

    public CardData findLowPowerCard(List<CardData> cards)
    {
        return sort.findLowPowerCard(cards);
    }    

    public CardData getRandomGameCard()
    {
        return sort.getRandomCard(gameLibrary.getCardList());
    }

    public CardData getRandomDeckCardHuman()
    {
        return deckLibrary.getRandomCard();
    }

    public CardData getRandomDeckCardAI()
    {
        return botDeckLibrary.getRandomCard();
    }

    public CardData getRandomPlayerCollectionsCard()
    {
        return gameLibrary.findCard(playerLibrary.getRandomIdCard());
    }    

    public List<CardData> getPoolPlayerCollectionCards() // get all player cards in list<CardData>
    { 
        return gameLibrary.findListCards(playerLibrary.getPlayerCards());
    }

    public List<CardData> getPoolTypeCards(string typeCard)
    {
        return sort.getListTypeCards(gameLibrary.getCardList(), typeCard);
    }


    public List<CardData> GetPoolCreature(List<CardData> cards)
    {
        return sort.getPoolCreature(cards);
    }

    public List<CardData> getPoolSpell(List<CardData> cards)
    {
        return sort.getPoolSpells(cards);
    }

    public List<CardData> getPoolAllGameSpells()
    {
        return sort.getPoolSpells(gameLibrary.getCardList());
    }


                                                                                                                                                                                                                                                                              
}    
