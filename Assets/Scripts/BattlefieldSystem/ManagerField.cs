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



        private void Start()
        {
            uiFieldController = GetComponent<UIFieldController>();
            fieldController = GetComponent<FieldController>();
        
        }



        public bool isfieldPlayCard(CardManager cardManager)
        {

            if (fieldController.IsCardOverBattlefield(cardManager.transform.position))
            {

                return true;

            }

            Debug.Log("field false");

            return false;


        }


        
        public void carate(CardManager cardManager)
        {
            if (cardManager.player is Player)
            {
                uiFieldController.changePlayerPowerText(cardManager.card.getPowerCard());
            }
            else
            {
                uiFieldController.changeEnemyPowerText(cardManager.card.getPowerCard());
            }
             
        }




    }
}
