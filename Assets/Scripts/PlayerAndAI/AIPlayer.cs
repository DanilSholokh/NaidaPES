using UnityEngine;

public class AIPlayer : PlayerBase
{





    public override void logicDrawCard()
    {
        hand.addHandCards(deck.getUpCard(), this);
    }

    public override void logicPlayCard(CardManager cardManager)
    {
        throw new System.NotImplementedException();
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
        EndTurn();
    }


    public void createAIDeck()
    {

        PoolsCardController poolsCardController = PoolsCardController.Instance;

        for (int i = 0; i < deckSize; i++)
        {
            deck.addCard(poolsCardController.getRandomGameCard());
        }

        Debug.Log("BOT deck Complete");

    }




}