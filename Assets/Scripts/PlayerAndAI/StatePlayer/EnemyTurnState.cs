using System.Collections;
using UnityEngine;

public class EnemyTurnState : IGamePlayState
{

    public void PlayCard(PlayerBase player, CardManager cardManager)
    {
        player.logicPlayCard(cardManager);

    }

    public void DrawCard(PlayerBase player)
    {
        Debug.Log("Enemy draw cardManager");

        player.logicDrawCard();
        



    }

    public void EndTurn(PlayerBase player)
    {
        Debug.Log("Enemy end Turn");
        player.SetState(new WaitingState()); // Переходимо до стану очікування
        player.gameManager.SwitchTurn(); // Передаємо хід іншому гравцю
    }

}