using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{

    public GameManager gameManager; // Ссылка на игру для переключения хода

    public DeckLibrary deck;
    public HandPlaceCards hand;


    // ======== Count Play Card
    public int maxCountPlayCreature = 1;
    public int maxCountPlaySpell = 1;
    public int currentPlayCreature = 0;
    public int currentPlaySpell = 0;

    //========== Count Deck
    public int deckSize = 9;

    protected IGamePlayState currentState;

    public virtual void SetState(IGamePlayState newState)
    {
        currentState = newState;
    }

    public virtual void PlayCard(CardManager card)
    {
        currentState.PlayCard(this, card);
    }

    public virtual void DrawCard()
    {
        currentState.DrawCard(this);
    }

    public virtual void EndTurn()
    { 
        currentState.EndTurn(this);
    }

    public void resetCountPlayCard()
    {
        currentPlayCreature = maxCountPlayCreature;
        currentPlaySpell = maxCountPlaySpell;
    }

    public abstract void logicPlayCard(CardManager cardManager);
    public abstract void logicDrawCard();




}