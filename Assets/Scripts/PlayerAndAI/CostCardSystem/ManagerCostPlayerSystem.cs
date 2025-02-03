using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCostPlayerSystem : MonoBehaviour
{


    private CostCardUI costUI;
    private PlayerCostController playerCost;



    private void Start()
    {
        playerCost = GetComponent<PlayerCostController>();
        costUI = GetComponent<CostCardUI>();

    }



    public bool isCostCreature(int cost)
    {
        if (playerCost.isMinusCountPlayCreature(cost))
        {
            playerCost.minusCountCraeature(cost);
            updateCurrentCostsUI();

            return true;
        }

        return false;
    }

    public bool isCostSpell(int cost)
    {
        if (playerCost.isMinusCountPlaySpell(cost))
        {
            playerCost.minusCountSpell(cost);
            updateCurrentCostsUI();

            return true;
        }

        return false;
    }


    public void resetToMaxCountCost()
    {
        playerCost.resetCountPlayCard();
        updateCurrentCostsUI();

    }

    public void updateCurrentCostsUI()
    {
        costUI.deleteAllSlots();
        costUI.addCreatureSlots(playerCost.getCurrentCreater());
        costUI.addSpellSlots(playerCost.getCurrentSpell());
    }


    
    public int getDeckSize()
    {
        return playerCost.getDeckSize(); 
    }


}
