using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellBarData
{

    public List<CardSpell> cardSpellsList = new List<CardSpell>();
    private List<CardManager> cardManagers = new List<CardManager>();


    public void addListCardSpell(CardSpell spell, CardManager cardManager)
    {
        cardSpellsList.Add(spell);
        cardManagers.Add(cardManager);
    }

    public CardManager removeListCardSpell(CardSpell spell)
    {

        if (cardSpellsList.Contains(spell))
        {
            int index = cardSpellsList.IndexOf(spell);
            CardManager cardManager = cardManagers[index];

            cardManagers.RemoveAt(index);
            cardSpellsList.Remove(spell);

            return cardManager;

        }


        return null;

    }



    public int getPowerSpells()
    {

        int sumPower = 0;

        for (int i = 0; i < cardSpellsList.Count; i++)
        {
            sumPower += cardSpellsList[i].getPowerCard();
        }

        return sumPower < 0 ? 0 : sumPower;


    }


    public void endTurnTriggerSpell(SpellBarUI barUI)
    {

        for (int i = cardSpellsList.Count - 1; i >= 0; i--)
        {
            if (cardSpellsList[i].isHitTurn() <= 0)
            {
                barUI.removeSpell(cardSpellsList[i], this);
            }

        }


    }


}
