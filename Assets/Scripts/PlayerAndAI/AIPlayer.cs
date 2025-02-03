using UnityEngine;

public class AIPlayer : PlayerBase
{

    public override void logicDrawCard()
    {
        hand.addHandCards(deck.getUpCard(), this);
    }

    public override void logicPlayCard(CardManager cardManager)
    {
        CardData card = cardManager.card;

        if (card.isCountCost(this))
        {

            card.PlayCard(this);
            cardManager.deleteCard();

        }

    }


    public override void SetState(IGamePlayState newState)
    {
        base.SetState(newState);
        if (newState is IGamePlayState)
        {
            TakeTurnAutomatically(); // Якщо це хід AI, він починає автоматично
        }
    }

    private void TakeTurnAutomatically()
    {
        // Логіка вибору дії AI
        Debug.Log("Ai turn ");
        DrawCard();

        //resetToMaxCountCost();
        endTurn();

    }

    private void endTurn()
    {
        resetMaxCosts();
        EndTurn();
    }


    public void createAIDeck()
    {

        PoolsCardController poolsCardController = PoolsCardController.Instance;

        for (int i = 0; i < costsSystem.getDeckSize(); i++)
        {
            deck.addCard(poolsCardController.getRandomGameCard());
        }

        Debug.Log("BOT deck Complete");

    }

    public override void setPower(CardData card)
    {
        PowerPlayer = gameManager.managerField.getEnemyPower();
        gameManager.managerField.setPowerStatusEnemy(card.getAddPowerCard(PowerPlayer));
    }
}