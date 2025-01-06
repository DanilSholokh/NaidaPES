using Assets.Scripts.BattlefieldSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������� ��� ���� ��������
public class HandPlaceCards : MonoBehaviour
{

    [SerializeField] private RectTransform handRectTransform; // ������, ��� ����� ������������ ����� � ����
    [SerializeField] private ManagerField field; // ������ ���� �����

    public GameManager gameManager;

    public int maxHandCard = 8;

    [SerializeField] private List<CardManager> handCardsList = new List<CardManager>();
    
    private CreateCard createCard;
    

    public int maxCardsPerRow = 4;
    public float rowSpacing = 150f;
    public float cardSpacing = 100f;
    public float offsetRange = 15f; // ĳ������ ����������� ������� ��� ������ ������������
    public float transitionDuration = 0.5f;

    public ManagerField Field { get => field; }

    private void Start()
    {
        createCard = new CreateCard();
    }

    public void addHandCards(CardData card, PlayerBase playerBase)
    {

        if (handCardsList.Count >= maxHandCard)
        {
            removeHandCards(handCardsList[0]);        
        }

        CardManager cardManager = createCard.CreateCardInstance(card, handRectTransform, playerBase);
        cardManager._gameManager = gameManager;
        handCardsList.Add(cardManager);
        
        cardManager._handPlaceCards = this;

        StartCoroutine(DelayedCalculatePlaceCreateCard());
    }

    private IEnumerator DelayedCalculatePlaceCreateCard()
    {
        yield return new WaitForEndOfFrame();
        calculatePlaceCreateCard();
    }

    public void StartCardPlacementCoroutine()
    {
        StartCoroutine(DelayedCalculatePlaceCreateCard());
    }

    public void removeHandCards(CardManager card)
    {
        // Animation delete card
        Destroy(card.gameObject);
        handCardsList.Remove(card);
        StartCoroutine(DelayedCalculatePlaceCreateCard());

    }

    private void calculatePlaceCreateCard()
    {

        float handWidth = handRectTransform.rect.width;
        float handHeight = handRectTransform.rect.height;

        for (int i = 0; i < handCardsList.Count; i++)
        {
            int row = i / maxCardsPerRow;  // ��� �����
            int column = i % maxCardsPerRow; // �������� �����

            // ���������� ������� ���� � ��������� ����
            int cardsInCurrentRow = Mathf.Min(maxCardsPerRow, handCardsList.Count - row * maxCardsPerRow);
            float rowWidth = (cardsInCurrentRow - 1) * cardSpacing; // ³������ �� ������� � ����

            // ������ ������� ��� ������� �����
            Vector3 basePosition = new Vector3(
                -rowWidth / 2 + column * cardSpacing, // ����������� ���� � ����
                -(row * rowSpacing) + (handHeight / 2 - rowSpacing / 2), // ����������� ���� �� ������ ����������
                0
            );

            // ������ �������� ������� ��� ���������� �������
            Vector3 randomOffset = new Vector3(
                Random.Range(-offsetRange, offsetRange),
                Random.Range(-offsetRange, offsetRange),
                0
            );

            // ʳ����� ������� ����� � ����������� �������
            Vector3 targetPosition = basePosition + randomOffset;

            // ��� ����� ����� �������� �������
            CardAnimation cardAnimation = handCardsList[i].cardAnimation;
            if (cardAnimation != null)
            {
                // ��������� ������� ��� ���������� �����
                cardAnimation.MoveToPosition(targetPosition, transitionDuration);
            }
            else
            {
                Debug.LogWarning($"Card at index {i} does not have a CardAnimation component!");
            }


        }


    }


}
