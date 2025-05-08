
public class Player : PlayerBase
{



    public override void logicPlayCard(CardManager cardManager)
    {

        if (cardManager.card.isCostPowerThanEnemyField(gameManager.ReferiSystem.getPowerStatusEnemy()))
        {

            if (gameManager.ReferiSystem.isCheckCardOnField(cardManager.transform.position))
            {

                if (cardManager.isPlayCostsCard())
                {
                    cardManager.PlayedCard();

                }

            }
        }

        


    
    }

    public override void logicDrawCard() 
    {
        hand.addHandCards(deck.getUpCard(), this);
    }

    public override void logicEndTurn()
    {
        //resetMaxCosts();
    }


    public void endTurn()
    {
        EndTurn();
    }


    public override void SetState(IGamePlayState newState)
    {
        base.SetState(newState);
    }

    public override void setPowerCreatures(CardData card)
    {
        gameManager.ReferiSystem.setCreaturePowerStatusPlayer(card);
    }

    public override void setPowerSpells(CardData card)
    {
        gameManager.ReferiSystem.setSpellPowerStatusPlayer(card);
        //gameManager.
    }


}   