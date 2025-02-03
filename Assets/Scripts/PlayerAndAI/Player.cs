using UnityEngine;
using UnityEngine.XR;

public class Player : PlayerBase
{



    public override void logicPlayCard(CardManager cardManager)
    {
        CardData card = cardManager.card;

        if (gameManager.isCheckCardOnField(cardManager.transform.position))
        {
            if (card.isCountCost(this))
            {
                gameManager.setfieldUI(cardManager);
                
                card.PlayCard();
                cardManager.deleteCard();
            
            }
            
        }
        
    }

    public override void logicDrawCard()
    {
        hand.addHandCards(deck.getUpCard(), this);
    }


    public void endTurn()
    {
        resetMaxCosts();
        EndTurn();
    }


    public override void SetState(IGamePlayState newState)
    {
        base.SetState(newState);
    }


}   