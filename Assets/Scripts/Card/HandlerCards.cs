using Assets.Scripts.BattlefieldSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HandlerCards : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler
{

    private Vector2 originalScale; // Хранит оригинальный масштаб
    //private LayoutElement layoutElement; // Ссылка на LayoutElement
    private RectTransform rectTransform; // Ссылка на RectTransform

    private Vector3 originalPosition;        // Stores the original position
    private int originalSiblingIndex;        // Stores the original sibling index for rendering priority

    private CardManager cardManager;
    private CardAnimation cardAnimation;

    private SelectCardsCreator panelSelectCards;

    public float enlargeScale = 1.2f;       // Фактор збільшення
    public float followSmoothness = 0.2f;   // Коефіцієнт згладжування для слідування за курсором


    private Camera uiCamera;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Получаем RectTransform
        cardManager = GetComponent<CardManager>();
        // Store the original scale

        


    }

    private void Start()
    {
        originalScale = rectTransform.localScale;
        cardAnimation = cardManager.cardAnimation;

        uiCamera = GameObject.FindWithTag("UICamera").GetComponent<Camera>();

    }

    public void setPanelTreeCard(SelectCardsCreator panelSelectCards)
    {
        this.panelSelectCards = panelSelectCards;
    }    

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (panelSelectCards == null)
        {
            cardAnimation.StopAnimation();

            // Store the original position and sibling index
            originalPosition = rectTransform.localPosition;
            originalSiblingIndex = rectTransform.GetSiblingIndex();

            // Increase size and bring to the front
            rectTransform.localScale = originalScale * 1.2f;
            rectTransform.SetAsLastSibling();

        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (panelSelectCards == null)
        {

            if (cardManager._handPlaceCards.Field.isfieldPlayCard(cardManager)) // if card played on battlegrounde
            {
                Debug.Log("card on battle field");
                cardManager.PlayCard();
                //return;
            }

            // Reset size and position, and restore sibling index
            rectTransform.localScale = originalScale;
            rectTransform.SetSiblingIndex(originalSiblingIndex);
            cardAnimation.MoveToPosition(originalPosition, 0.3f);


        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (panelSelectCards != null)
        {
            panelSelectCards.addCard(cardManager.card);
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (panelSelectCards == null)
        {
            // Робить так, щоб карта слідувала за курсором з плавним рухом
            Vector3 targetPosition = uiCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, uiCamera.nearClipPlane));
            targetPosition.z = rectTransform.position.z; // Сохраняем текущую ось Z
            rectTransform.position = Vector3.Lerp(rectTransform.position, targetPosition, followSmoothness);

        }

    }


}
