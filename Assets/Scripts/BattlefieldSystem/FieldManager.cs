using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class FieldManager : MonoBehaviour
    {

        public UIFieldController uiFieldController;

        private FieldController fieldController;
        //private CalculateFieldRule ruleField;

        private SpellBarUI spellBar;


        private void Awake()
        {
            uiFieldController = GetComponent<UIFieldController>();
            fieldController = GetComponent<FieldController>();
            //ruleField = GetComponent<CalculateFieldRule>();
            spellBar = GetComponent<SpellBarUI>();

        }








        public void addSpellBarPlayer(CardData card, PlayerBase playerBase, PlayerSpellBarData playerBarData) // !!! setup for spell played
        {
            spellBar.addSpell(card, playerBase, uiFieldController.getPlayerSpell(), playerBarData);
        }

        public void addSpellBarEnemy(CardData card, PlayerBase playerBase, PlayerSpellBarData playerBarData)  // !!! setup for spell played
        {
            spellBar.addSpell(card, playerBase, uiFieldController.getEnemySpell(), playerBarData);
        }


        public bool isfieldPlayCard(Vector3 position)
        {
            return fieldController.IsCardOverBattlefield(position);
        }



        //public int getSumPlayerPower()
        //{
        //    return ruleField.getSumPowerPlayer();
        //}

        //public int getSumEnemyPower()
        //{
        //    return ruleField.getSumPowerEnemy();
        //}


        //Creature
        //public void setPowerStatusPlayer(int power)
        //{
        //    ruleField.setPowerCreaturePlayer(power);
        //    updateUIFieldStatus();

        //}

        //public void setPowerStatusEnemy(int power)
        //{
        //    ruleField.setPowerCreatureEnemy(power);
        //    updateUIFieldStatus();

        //}


        //public void addPowerPlayer(int power)
        //{
        //    ruleField.addPowerCreaturePlayer(power);
        //    updateUIFieldStatus();
        //}

        //public void addPowerEnemy(int power)
        //{
        //    ruleField.addPowerCreatureEnemey(power);
        //    updateUIFieldStatus();
        //}    

        //public void removePowerPlayer(int power)
        //{
        //    ruleField.removeCreaturePowerPlayer(power);
        //    updateUIFieldStatus();
        //}

        //public void removePowerEnemy(int power)
        //{
        //    ruleField.removeCreaturePowerEnemy(power);
        //    updateUIFieldStatus();
        //}



        ////spell
        //public void setSpellPowerPlayer(int power)
        //{
        //    ruleField.setPowerSpellPlayer(power);
        //    updateUIFieldStatus();

        //}

        //public void setSpellPowerEnemy(int power)
        //{
        //    ruleField.setPowerSpellEnemy(power);
        //    updateUIFieldStatus();

        //}


        //public void addSpellPowerPlayer(int power)
        //{
        //    ruleField.addPowerSpellPlayer(power);
        //    updateUIFieldStatus();
        //}

        //public void addSpellPowerEnemy(int power)
        //{
        //    ruleField.addPowerSpellEnemy(power);
        //    updateUIFieldStatus();
        //}

        //public void removeSpellPowerPlayer(int power)
        //{
        //    ruleField.removePowerSpellPlayer(power);
        //    updateUIFieldStatus();
        //}

        //public void removeSpellPowerEnemy(int power)
        //{
        //    ruleField.removePowerSpellEnemy(power);
        //    updateUIFieldStatus(); 
        //}



        public void updateUIFieldStatus(ReferiController referi)
        {
            uiFieldController.changePlayerPowerText(referi.getRefreshPlayerPower());
            uiFieldController.changeEnemyPowerText(referi.getRefreshEnemyPower());
        }


    }
}
