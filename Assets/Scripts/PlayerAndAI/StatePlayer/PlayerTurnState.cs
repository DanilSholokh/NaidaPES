using UnityEngine;

public class PlayerTurnState : IGamePlayState
{
    public void PlayCard(PlayerBase player, CardManager cardManager)
    {
        
        player.logicPlayCard(cardManager);


    }

    public void DrawCard(PlayerBase player)
    {
        Debug.Log("player draws a cardManager.");
        player.logicDrawCard();
    }

    public void EndTurn(PlayerBase player)
    {
        Debug.Log("player ends their turn.");
        player.SetState(new WaitingState()); // Переходимо до стану очікування

        player.gameManager.SwitchTurn(); // Передаємо хід іншому гравцю
    }

}