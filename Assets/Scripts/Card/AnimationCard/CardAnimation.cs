using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    // Параметры для анимации левитации
    public float maxHoverHeight = 10f;
    public float minHoverHeight = 3f;
    public float maxAnimationDuration = 6f;
    public float minAnimationDuration = 4f;

    public float maxRotate = 5f;
    public float minRotate = -5f;

    // Параметры для возврата
    public float returnHeightOffset = 10f;
    public float returnAnimationDuration = 4f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        AnimateCard(); // Запускаем анимацию "левитации"
    }

    private void AnimateCard()
    {
        // Сохраняем текущую позицию как базовую точку отсчёта
        Vector3 startLocalPosition = rectTransform.localPosition;
        float randomHoverHeight = Random.Range(minHoverHeight, maxHoverHeight);
        float randomAnimationDuration = Random.Range(minAnimationDuration, maxAnimationDuration);

        rectTransform.DOLocalMoveY(startLocalPosition.y + randomHoverHeight, randomAnimationDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                rectTransform.DOLocalMoveY(startLocalPosition.y, randomAnimationDuration)
                    .SetEase(Ease.InOutSine)
                    .OnComplete(() => AnimateCard());
            });

        // Задаем случайное вращение в диапазоне для движения влево и вправо
        float randomRotationZ = Random.Range(minRotate, maxRotate);
        rectTransform.DOLocalRotate(new Vector3(0, 0, randomRotationZ), randomAnimationDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                // Возвращаем карту к нулевому углу для предотвращения накопления поворота
                rectTransform.DOLocalRotate(Vector3.zero, randomAnimationDuration)
                    .SetEase(Ease.InOutSine);
            });

    }

    public void MoveToPosition(Vector3 targetPosition, float duration)
    {
        StopAnimation(); // Останавливаем текущую анимацию перед перемещением

        rectTransform.DOLocalMove(targetPosition, duration)
            .SetEase(Ease.InOutQuad)
            .OnComplete(() => AnimateCard()); // Перезапускаем анимацию после перемещения
    }

    public void StopAnimation()
    {
        rectTransform.DOKill(); // Останавливаем все текущие анимации на карте
    }



}




