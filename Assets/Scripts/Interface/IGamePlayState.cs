public interface IGamePlayState
{
    void PlayCard(PlayerBase player, CardManager cardManager);
    void DrawCard(PlayerBase player);
    void EndTurn(PlayerBase player);



}
