using System.Collections.Generic;
using UnityEngine;

// карти ігрока
public class PlayerCardLibrary : MonoBehaviour
{

    [SerializeField] private List<int> playerListCards;

    private GameCardsLibrary gameCards;
    private AmazingPack amazing;

    void Awake()
    {
        gameCards = GetComponent<GameCardsLibrary>();
        amazing = GetComponent<AmazingPack>();
        
        initPlayerCards();
    }

    private void initPlayerCards()  
    {
        playerListCards.Clear();

        List<int> allCards = new List<int>();
        gameCards.getIdCardList(allCards);

        foreach (int cardId in allCards)
        {
            if (PlayerPrefs.GetInt("DeckLibrary " + cardId, 0) == 1)
            {
                playerListCards.Add(cardId);
            }
        }

    }

    public List<int> getPlayerCards()
    {
        initPlayerCards();

        return playerListCards;

    }


    public int getRandomIdCard()
    {
        return playerListCards[Random.Range(0, playerListCards.Count)];
    }

    
}
