using UnityEngine;

public class PlayerCostController : MonoBehaviour
{


    // ======== Count Play Card
    [SerializeField] private int maxCountPlayCreature = 1;
    [SerializeField] private int maxCountPlaySpell = 1;
    [SerializeField] private int currentPlayCreature = 0;
    [SerializeField] private int currentPlaySpell = 0;

    //========== Count Deck
    [SerializeField] private int deckSize = 9;



    public bool isMinusCountPlaySpell(int cost)
    {
        if (getCurrentSpell() >= cost)
        {
            return true;
        }

        return false;
    }


    public bool isMinusCountPlayCreature(int cost)
    {
        if (getCurrentCreater() >= cost)
        {
            return true;
        }

        return false;
    }

    public void minusCountSpell(int cost)
    {
        if (isMinusCountPlaySpell(cost))
        {
            currentPlaySpell -= cost;
        }
    }

    public void minusCountCraeature(int cost)
    {
        if (isMinusCountPlayCreature(cost))
        {
            currentPlayCreature -= cost;
        }
        
    }

    public int getMaxCreature()
        { return maxCountPlayCreature; }

    public int getMaxSpell() 
    { return maxCountPlaySpell; }

    public int getCurrentCreater()
    {
        return currentPlayCreature;
    }

    public int getCurrentSpell()
    {
        return currentPlaySpell;
    }

    public int getDeckSize()
    {
        return deckSize; 
    }

    public void resetCountPlayCard()
    {
        currentPlayCreature = maxCountPlayCreature;
        currentPlaySpell = maxCountPlaySpell;

    }



}
