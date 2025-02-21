using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CardPlace
{
    public class AnimHandCards : MonoBehaviour
    {


        public RectTransform handRectTransform; // Панель, где будут отображаться карты в руке
        private HandPlaceManager handPlace;


        public int maxCardsPerRow = 4;
        public float rowSpacing = 350f;
        public float cardSpacing = 200f;
        public float offsetRange = 15f; // Діапазон випадкового зміщення для ефекту «незграбності»
        public float transitionDuration = 0.5f;

        public HandPlaceManager HandPlace {set => handPlace = value; }

        public IEnumerator DelayedCalculatePlaceCreateCard()
        {
            yield return new WaitForEndOfFrame();
            calculatePlaceCreateCard();
        }


        

        private void calculatePlaceCreateCard()
        {

            float handWidth = handRectTransform.rect.width;
            float handHeight = handRectTransform.rect.height;

            for (int i = 0; i < handPlace.handCardsList.Count; i++)
            {
                int row = i / maxCardsPerRow;  // Ряд карти
                int column = i % maxCardsPerRow; // Стовпчик карти

                // Обчислюємо кількість карт в поточному ряду
                int cardsInCurrentRow = Mathf.Min(maxCardsPerRow, handPlace.handCardsList.Count - row * maxCardsPerRow);
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
                CardAnimation cardAnimation = handPlace.handCardsList[i].cardAnimation;
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
}