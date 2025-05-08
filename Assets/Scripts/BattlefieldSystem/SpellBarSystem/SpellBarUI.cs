using System.Collections.Generic;
using UnityEngine;

public class SpellBarUI : MonoBehaviour
{



    private CreateCard createCard;

    private List<CardSpell> cardSpells = new List<CardSpell>();
    private List<CardManager> cardManagers = new List<CardManager>();


    private void Start()
    {
        createCard = new CreateCard();
    }






    public void addSpell(CardData card, PlayerBase playerBase, Transform transform, PlayerSpellBarData playerBarData)
    {
        if (card is CardSpell cardSpell)
        {
            CardManager cardManager = createCard.CreateCardInstance(cardSpell, transform, playerBase);
            
            cardManager.setUICard();
            playerBarData.addListCardSpell(cardSpell, cardManager);


            //cardManager.cardAnimation.StopAnimation();
        }


    }


    public void removeSpell(CardSpell cardSpell, PlayerSpellBarData playerBarData)
    {
        CardManager deleteCard = playerBarData.removeListCardSpell(cardSpell);

        if (deleteCard != null)
        {
            deleteCard.deleteCard();
        }
        else
        { Debug.LogWarning(this + " cant delete spell"); }    

    }

    




}
