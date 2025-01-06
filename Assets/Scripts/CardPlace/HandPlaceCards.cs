using Assets.Scripts.BattlefieldSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// хендлер для карт менеджер
public class HandPlaceCards : MonoBehaviour
{

    [SerializeField] private RectTransform handRectTransform; // Панель, где будут отображаться карты в руке
    [SerializeField] private ManagerField field; // Панель поле битви

    public GameManager gameManager;

    public int maxHandCard = 8;

    [SerializeField] private List<CardManager> handCardsList = new List<CardManager>();
    
    private CreateCard createCard;
    

    public int maxCardsPerRow = 4;
    public float rowSpacing = 150f;
    public float cardSpacing = 100f;
    public float offsetRange = 15f; // Діапазон випадкового зміщення для ефекту «незграбності»
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
            int row = i / maxCardsPerRow;  // Ряд карти
            int column = i % maxCardsPerRow; // Стовпчик карти

            // Обчислюємо кількість карт в поточному ряду
            int cardsInCurrentRow = Mathf.Min(maxCardsPerRow, handCardsList.Count - row * maxCardsPerRow);
            float rowWidth = (cardsInCurrentRow - 1) * cardSpacing; // Відстань між картами в ряду

            // Базова позиція для поточної карти
            Vector3 basePosition = new Vector3(
                -rowWidth / 2 + column * cardSpacing, // Центрування карт в ряду
                -(row * rowSpacing) + (handHeight / 2 - rowSpacing / 2), // Вирівнювання рядів по центру контейнера
                0
            );

            // Додаємо випадкові зміщення для хаотичного вигляду
            Vector3 randomOffset = new Vector3(
                Random.Range(-offsetRange, offsetRange),
                Random.Range(-offsetRange, offsetRange),
                0
            );

            // Кінцева позиція карти з урахуванням зміщення
            Vector3 targetPosition = basePosition + randomOffset;

            // Для кожної карти включаємо анімацію
            CardAnimation cardAnimation = handCardsList[i].cardAnimation;
            if (cardAnimation != null)
            {
                // Запускаємо анімацію для переміщення карти
                cardAnimation.MoveToPosition(targetPosition, transitionDuration);
            }
            else
            {
                Debug.LogWarning($"Card at index {i} does not have a CardAnimation component!");
            }


        }


    }


}
