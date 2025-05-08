using Assets.Scripts.BattlefieldSystem;
using UnityEngine;

// установлює інформацію про карту в візуальний формат
public class CardManager : MonoBehaviour
{


    public CardData card;


    public HandlerCards Handler;
    public CardAnimation cardAnimation;

    private UICardController uiController;
    
    private GameManager gameManager;
    private HandPlaceManager handPlace;

    public PlayerBase player;

    public HandPlaceManager _handPlaceCards { get => handPlace; set => handPlace = value; }
    public GameManager _gameManager { set => gameManager = value; }

    public void setDataCard(PlayerBase playerBase)
    {

        if (card != null)
        {
            cardAnimation = GetComponent<CardAnimation>();
            Handler = GetComponent<HandlerCards>();
            uiController = GetComponent<UICardController>();

            player = playerBase;
            

        }       

    }

    public void setUICard()
    {
        uiController.initIUdata(card);
    }

    public void setUILookBlockDetect()
    {
        if (player is AIPlayer)
        {
            uiController.activeCardBack();
        }
        else
        {
            setUICard();
        }

    }

    public void tryPlayCard()
    {
        if (gameManager.currentPlayer != null)
        {
            player.PlayCard(this);
            return;
        }

        Debug.Log("null player card");

    }

    public bool isPlayCostsCard()
    {
        return card.isCountCost(player);
    }


    public void PlayedCard()
    {
        card.PlayCard(player);
        deleteCard();
    }


    public void deleteCard()
    {
        handPlace.removeHandCards(this);
    }


    private int getCardPower()
    {
        return card.getPowerCard();
    }


}
