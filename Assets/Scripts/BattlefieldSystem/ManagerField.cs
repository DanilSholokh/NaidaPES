using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class ManagerField : MonoBehaviour
    {


        private CardCreature playerCardCreature;
        private CardCreature enemyCardCreature;

        private CardSpell playerSpell;
        private CardSpell enemySpell;


        private UIFieldController uiFieldController;
        private FieldController fieldController;
        private CardFieldHandler cardField;

        [SerializeField] GameManager gameManager;

        public FieldController FieldController { get { return fieldController; } }
        public CardFieldHandler CardField { get { return cardField; } }


        private void Start()
        {
            uiFieldController = GetComponent<UIFieldController>();
            fieldController = GetComponent<FieldController>();
        
        }



        public bool fieldPlayCard(CardManager cardManager)
        {

            if (FieldController.IsCardOverBattlefield(cardManager.transform.position))
            {
                return true;
            }

            Debug.Log("field false");

            return false;


        }


    }
}
