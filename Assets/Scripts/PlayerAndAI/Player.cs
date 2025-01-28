using UnityEngine;
using UnityEngine.XR;

public class Player : PlayerBase
{


    public override void logicPlayCard(CardManager cardManager)
    {
        cardManager.card.PlayCard();
        cardManager.deleteCard();
    }

    public override void logicDrawCard()
    {
        hand.addHandCards(deck.getUpCard(), this);
    }


    public void endTurn()
    {
        EndTurn();
    }


    public override void SetState(IGamePlayState newState)
    {
        base.SetState(newState);
    }


}   