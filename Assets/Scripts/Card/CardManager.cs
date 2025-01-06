using UnityEngine;

// установлює інформацію про карту в візуальний формат
public class CardManager : MonoBehaviour
{


    public CardData card;


    public HandlerCards Handler;
    public CardAnimation cardAnimation;

    private UICardController uiController;
    
    private GameManager gameManager;
    private HandPlaceCards handPlace;

    public PlayerBase player;

    public HandPlaceCards _handPlaceCards { get => handPlace; set => handPlace = value; }
    public GameManager _gameManager { set => gameManager = value; }

    public void setDataCard(PlayerBase playerBase)
    {

        if (card != null)
        {
            cardAnimation = GetComponent<CardAnimation>();
            Handler = GetComponent<HandlerCards>();
            uiController = GetComponent<UICardController>();

            player = playerBase;

            if (player is Player)
            {
                uiController.initIUdata(card);
            }
            else
            {
                uiController.activeCardBack();
            }
        }       

    }


    public void PlayCard()
    {
        if (gameManager.currentPlayer != null)
        {
            gameManager.playCardOnField(this);
        }




    }

    public void deleteCard()
    {
        handPlace.removeHandCards(this);
    }




}
