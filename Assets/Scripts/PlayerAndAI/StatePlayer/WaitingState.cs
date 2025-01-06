using UnityEngine;

public class WaitingState : IGamePlayState
{
    public void PlayCard(PlayerBase player, CardManager cardManager)
    {
        Debug.Log(" cannot play a card while waiting.");
    }

    public void DrawCard(PlayerBase player)
    {
        Debug.Log(" cannot draw a card while waiting.");
    }

    public void EndTurn(PlayerBase player)
    {
        Debug.Log(" cannot end the turn while waiting.");
    }
}