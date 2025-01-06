using UnityEngine;

public class CreateCard
{

    public PoolsCardController poolsCard;
    private CardManager cardManager;

    // Конструктор класу CreateCard
    public CreateCard()
    {
        poolsCard = PoolsCardController.Instance;
        cardManager = Resources.Load<CardManager>("Prefab/Card");

    }

    // Метод для створення картки
    public CardManager CreateCardInstance(CardData card, Transform placeCard, PlayerBase playerBase)
    {
        // Замість Instantiate ви можете створити об'єкт прямо
        CardManager managerCard = Object.Instantiate(cardManager, placeCard);
        managerCard.card = card;
        
        managerCard.setDataCard(playerBase);

        return managerCard;
    }



}
