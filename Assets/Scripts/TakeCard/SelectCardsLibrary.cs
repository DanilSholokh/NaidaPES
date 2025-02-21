using UnityEngine;

//panel select cards for create NEW deck
public class SelectCardsLibrary : SelectCardsCreator
{

    private DeckLibrary deckLibrary;
    private int countSelectCards = 3;

    public SelectCardsLibrary(PlayerBase playerBase) : base(playerBase)
    {
        this.playerBase = playerBase;
    }

    public override void createPrefabPanel()
    {
        initClass(countSelectCards);
        deckLibrary = createCard.poolsCard.deckLibrary;

        if (!deckLibrary.IsDeckFull())
        {
            createTreeCard();
        }                                                    

    }                               

    public override void addCard(CardData cardData)
    {

        if (!deckLibrary.IsDeckFull())// size of the deck depend on number of cards 
        {
            deckLibrary.addCard(cardData);
            createTreeCard();

        }
        else
        {
            deckLibrary.addCard(cardData);
            Object.Destroy(panelTreeCardPrefab.gameObject);

        }

    }





}
