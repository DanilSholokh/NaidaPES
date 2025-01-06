using Assets.Scripts.BattlefieldSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player humanPlayer;
    public AIPlayer aiPlayer;
    public PlayerBase currentPlayer;
    
    public ManagerField managerField;



    public void gameStart()
    {

        aiPlayer.createAIDeck();
        // create player handle card

        humanPlayer.deck.shuffleDeck();
        aiPlayer.deck.shuffleDeck();
        startHumanTurn();

        


    }

    public void SwitchTurn()
    {
        if (currentPlayer == humanPlayer)
        {
            currentPlayer = aiPlayer; // Передача ходу AI
            currentPlayer.SetState(new EnemyTurnState());
        }
        else
        {
            currentPlayer = humanPlayer; // Передача ходу гравцю
            currentPlayer.SetState(new PlayerTurnState());
        }

    }

    private void startHumanTurn()
    {
        currentPlayer = humanPlayer; // Передача ходу гравцю
        currentPlayer.SetState(new PlayerTurnState());
        humanPlayer.currentPlayCreature = humanPlayer.maxCountPlayCreature; 

    }


    public void playCardOnField(CardManager cardManager)
    {
        
        if (managerField.fieldPlayCard(cardManager))
        {
            Debug.Log("card on battle field 2");
            cardManager.player.PlayCard(cardManager);

        }


        
    }



}
