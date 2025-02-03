using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class ManagerField : MonoBehaviour
    {

        private UIFieldController uiFieldController;
        private FieldController fieldController;
        private CalculateFieldRule ruleField;

        [SerializeField] GameManager gameManager;



        private void Start()
        {
            uiFieldController = GetComponent<UIFieldController>();
            fieldController = GetComponent<FieldController>();
            ruleField = GetComponent<CalculateFieldRule>();   
        
        }

        public bool isfieldPlayCard(Vector3 position)
        {

            if (fieldController.IsCardOverBattlefield(position))
            {
 
                return true;

            }


            return false;


        }


        public void setfieldUpdate(CardManager cardManager) // update power 
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



        public void setPowerStatusPlayer(int power)
        {
            ruleField.setPowerPlayer(power);
            updateUIFieldStatus();

        }

        public void setPowerStatusEnemy(int power)
        {
            ruleField.setPowerPlayer(power);
            updateUIFieldStatus();

        }


        public void addPowerPlayer(int power)
        {
            ruleField.addPowerPlayer(power);
            updateUIFieldStatus();
        }

        public void addPowerEnemy(int power)
        {
            ruleField.addPowerEnemey(power);
            updateUIFieldStatus();
        }    

        public void removePowerPlayer(int power)
        {
            ruleField.removePowerPlayer(power);
            updateUIFieldStatus();
        }

        public void removePowerEnemy(int power)
        {
            ruleField.removePowerEnemy(power);
            updateUIFieldStatus();
        }

        public int getPlayerPower()
        {
            return ruleField.getPowerPlayer();
        }

        public int getEnemyPower()
        {
            return ruleField.getPowerEnemy();
        }


        private void updateUIFieldStatus()
        {
            uiFieldController.changePlayerPowerText(ruleField.getPowerPlayer());
            uiFieldController.changeEnemyPowerText(ruleField.getPowerPlayer());
        }


    }
}
