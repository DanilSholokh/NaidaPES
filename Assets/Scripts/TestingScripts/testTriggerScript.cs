using UnityEngine;

public class testTriggerScript : MonoBehaviour
{

    [SerializeField] PlayerCardLibrary Pcard;
    [SerializeField] GameCardsLibrary Gcard;
    [SerializeField] CreateCard createHandCards;

    [SerializeField] DeckLibrary deckLibrary;
    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;


    public void triggerBuy()
    {

        int r_id = Random.Range(0, 6);

        Debug.Log("" + r_id + " card buy");
        Gcard.buyCards(r_id);


    }

    public void triggerSell()
    {
        
        
        for (int i = 0; i < 34; i++)
        {
            Gcard.sellCards(i);
        }

        
    }

    public void startPlayGame()
    {
        gameManager.gameStart();
    }

    public void switchTurn()
    {
        player.endTurn();
    }


    public void createCardHand()
    {
        SelectCardsHands selectCardsHands = new SelectCardsHands(player, 2);
        selectCardsHands.createPrefabPanel();
    }


    public void createDeck()
    {
        SelectCardsLibrary createGameDeck = new SelectCardsLibrary(player);
        createGameDeck.createPrefabPanel();


    }

    public void addCardHand()
    {

    }
    




}
