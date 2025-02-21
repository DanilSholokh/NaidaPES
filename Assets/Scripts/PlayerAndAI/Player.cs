
public class Player : PlayerBase
{



    public override void logicPlayCard(CardManager cardManager)
    {
        CardData card = cardManager.card;

        if (gameManager.isCheckCardOnField(cardManager.transform.position))
        {
            if (card.isCountCost(this))
            {

                card.PlayCard(this);
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

    public override void setPower(CardData card)
    {
        PowerPlayer = gameManager.managerField.getPlayerPower();
        gameManager.managerField.setPowerStatusPlayer(card.getAddPowerCard(PowerPlayer));
    }
}   