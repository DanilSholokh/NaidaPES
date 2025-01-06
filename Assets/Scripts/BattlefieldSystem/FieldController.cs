using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class FieldController : MonoBehaviour
    {

        [SerializeField] RectTransform rectField;


        public bool IsCardOverBattlefield(Vector3 cardPosition)
        {
            // Перетворюємо позицію карти у координати екрану перед перевіркою
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(cardPosition);
            return RectTransformUtility.RectangleContainsScreenPoint(
                rectField,
                screenPoint,
                Camera.main
            );
        }

    }



}