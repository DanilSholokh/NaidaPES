using UnityEngine;

public class CreateCard
{

    public PoolsCardController poolsCard;
    private CardManager cardManager;

    // ����������� ����� CreateCard
    public CreateCard()
    {
        poolsCard = PoolsCardController.Instance;
        cardManager = Resources.Load<CardManager>("Prefab/Card");

    }

    // ����� ��� ��������� ������
    public CardManager CreateCardInstance(CardData card, Transform placeCard, PlayerBase playerBase)
    {
        // ������ Instantiate �� ������ �������� ��'��� �����
        CardManager managerCard = Object.Instantiate(cardManager, placeCard);
        managerCard.card = card;
        
        managerCard.setDataCard(playerBase);

        return managerCard;
    }



}
