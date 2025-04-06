using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCostPlayedCardSystem : MonoBehaviour
{


    private CostCardUI costUI;
    private CostPlayedCardController playerCost;



    private void Start()
    {
        playerCost = GetComponent<CostPlayedCardController>();
        costUI = GetComponent<CostCardUI>();

    }



    public bool isCostCreature(int cost)
    {
        if (playerCost.isMinusCountPlayCreature(cost))
        {
            playerCost.minusCountPlayedCostCraeature(cost);
            updateCurrentPlayedCostsUI();

            return true;
        }

        return false;
    }

    public bool isCostSpell(int cost)
    {
        if (playerCost.isMinusCountPlaySpell(cost))
        {
            playerCost.minusCountPlayedCostSpell(cost);
            updateCurrentPlayedCostsUI();

            return true;
        }

        return false;
    }


    public void resetToMaxCountPlayedCost()
    {
        playerCost.resetCountPlayedCostCard();
        updateCurrentPlayedCostsUI();

    }

    public void updateCurrentPlayedCostsUI()
    {
        costUI.deleteAllSlots();
        costUI.addCreatureSlots(playerCost.getCurrentPlayedCostCreater());
        costUI.addSpellSlots(playerCost.getCurrentPlayedCostSpell());
    }


    public int getCurrentCostSlotSpell()
    {
        return playerCost.getCurrentPlayedCostSpell();
    }
    

}
