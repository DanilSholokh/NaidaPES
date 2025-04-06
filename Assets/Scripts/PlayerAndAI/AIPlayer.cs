using UnityEngine;

public class AIPlayer : PlayerBase
{


    [SerializeField] private AiBrainManager brain;

    public override void logicDrawCard()
    {
        brain.drawCardLogic();
    }

    public override void logicPlayCard(CardManager cardManager)
    {

        cardManager.PlayedCard();

        //if (cardManager.card.isCostPowerThanEnemyField(gameManager.managerField.getSumPlayerPower()))
        //{
        //    if (cardManager.isPlayCostsCard())
        //    {
        //        cardManager.PlayedCard();
        //    }
        //}
        //else
        //{
        //    Debug.Log("not enough creature power, AI");
        //}


    }


    public override void logicEndTurn()
    {
        brain.endTurn();
    }


    public override void SetState(IGamePlayState newState)
    {
        base.SetState(newState);
        if (newState is EnemyTurnState)
        {
            TakeTurnAutomatically(); // Якщо це хід AI, він починає автоматично

        }
    }

    private void TakeTurnAutomatically()
    {
        // Логіка вибору дії AI
        Debug.Log("Ai turn ");

        brain.startTurn();
        //DrawCard();


        endTurn();

    }

    public void endTurn()
    {
        EndTurn();
    }

    public void SetupGame()
    {
        brain.setBrainData(this);
        brain.createDeck();
        brain.createStartHand();
    }    

    public override void setPowerCreatures(CardData card)
    {
        gameManager.ReferiSystem.setCreaturePowerStatusEnemy(card);

    }

    public override void setPowerSpells(CardData card)
    {
        gameManager.ReferiSystem.setSpellPowerStatusEnemy(card);

    }



}