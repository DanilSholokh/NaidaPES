using UnityEngine;

public class SelectCardsHands : SelectCardsCreator
{


    private HandPlaceCards HandPlace;
    int count = 0;

    public SelectCardsHands(PlayerBase playerBase ,int countCards) : base(playerBase)
    {
        count = countCards;
        this.playerBase = playerBase;
    }

    public override void addCard(CardData card)
    {
        
        HandPlace.addHandCards(card, playerBase);
        Object.Destroy(panelTreeCardPrefab.gameObject);

    }

    public override void createPrefabPanel()
    {
        initClass(count);
        HandPlace = createCard.poolsCard.handPlaceCardsPlayer;

        if (HandPlace != null)
        {
            createTreeCard();
        }


    }
}
