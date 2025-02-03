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
        humanPlayer.resetMaxCosts();
        aiPlayer.resetMaxCosts();
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

    public void setfieldUI(CardManager cardManager)
    {
        managerField.setfieldUpdate(cardManager);
    }

    public bool isCheckCardOnField(Vector3 positionCard)
    {
        return managerField.isfieldPlayCard(positionCard);
    }    

    private void startHumanTurn()
    {
        currentPlayer = humanPlayer; // Передача ходу гравцю
        currentPlayer.SetState(new PlayerTurnState()); 

    }



    




}
