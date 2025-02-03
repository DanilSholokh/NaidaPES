using Assets.Scripts.BattlefieldSystem;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{

    public GameManager gameManager; // Ссылка на игру для переключения хода

    public DeckLibrary deck;
    public HandPlaceCards hand;

    public ManagerCostPlayerSystem costsSystem;


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


    public bool creatureCostUpdate(int cost)
    {
        return costsSystem.isCostCreature(cost);
    }

    public bool spellCostUpdate(int cost)
    {
        return costsSystem.isCostSpell(cost);
    }

    public void resetMaxCosts()
    {
        costsSystem.resetToMaxCountCost();
    }


    public abstract void logicPlayCard(CardManager cardManager);
    public abstract void logicDrawCard();




}