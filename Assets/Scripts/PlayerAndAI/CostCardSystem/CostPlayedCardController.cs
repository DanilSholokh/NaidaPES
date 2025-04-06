using UnityEngine;

public class CostPlayedCardController : MonoBehaviour
{


    // ======== Count Play Card
    [SerializeField] private int maxCountPlayCreature = 1;
    [SerializeField] private int maxCountPlaySpell = 1;

    [SerializeField] private int currentPlayCreature = 0;
    [SerializeField] private int currentPlaySpell = 0;




    public bool isMinusCountPlaySpell(int cost)
    {
        if (getCurrentPlayedCostSpell() >= cost)
        {
            return true;
        }

        return false;
    }


    public bool isMinusCountPlayCreature(int cost)
    {
        if (getCurrentPlayedCostCreater() >= cost)
        {
            return true;
        }

        return false;
    }

    public void minusCountPlayedCostSpell(int cost)
    {
        if (isMinusCountPlaySpell(cost))
        {
            currentPlaySpell -= cost;
        }
    }

    public void minusCountPlayedCostCraeature(int cost)
    {
        if (isMinusCountPlayCreature(cost))
        {
            currentPlayCreature -= cost;
        }
        
    }

    public int getMaxPlayedCostCreature()
        { return maxCountPlayCreature; }

    public int getMaxPlayedCostSpell() 
    { return maxCountPlaySpell; }

    public int getCurrentPlayedCostCreater()
    {
        return currentPlayCreature;
    }

    public int getCurrentPlayedCostSpell()
    {
        return currentPlaySpell;
    }


    public void resetCountPlayedCostCard()
    {
        currentPlayCreature = maxCountPlayCreature;
        currentPlaySpell = maxCountPlaySpell;
    }



}
