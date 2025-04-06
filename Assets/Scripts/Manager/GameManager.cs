using Assets.Scripts.BattlefieldSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player humanPlayer;
    public AIPlayer aiPlayer;
    public PlayerBase currentPlayer;
    
    public ReferiController ReferiSystem;
    


    public void gameStart()
    {
        ReferiSystem.prepareGame(this);
        aiPlayer.SetupGame();
        // create player handle card

        humanPlayer.deck.shuffleDeck();
        aiPlayer.deck.shuffleDeck();

        startHumanTurn();
        



    }

    public void SwitchTurn()
    {

        if (currentPlayer == humanPlayer)
        {
            startAiTurn();
        }
        else
        {
            startHumanTurn();
        }


    }
    

    private void startHumanTurn()
    {
        humanPlayer.UpdateDataTurn();
        currentPlayer = humanPlayer; // Передача ходу гравцю
        currentPlayer.SetState(new PlayerTurnState()); 
        

    }

    private void startAiTurn()
    {
        aiPlayer.UpdateDataTurn();
        currentPlayer = aiPlayer; // Передача ходу AI
        currentPlayer.SetState(new EnemyTurnState());

    }


   

}
