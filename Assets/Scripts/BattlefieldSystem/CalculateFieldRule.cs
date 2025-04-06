using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class CalculateFieldRule : MonoBehaviour
    {

        int powerPlayerCreature = 0;
        int powerEnemyCreature = 0;

        private int powerPlayerSpell = 0;
        private int powerEnemySpell = 0;

        private int sumPowerPlayer = 0;
        private int sumPowerEnemy = 0;


        public int getPowerPlayerCreature() { return powerPlayerCreature; }
        public int getPowerEnemyCreature() { return powerEnemyCreature; }

        public int getPowerEnemySpell() { return powerEnemySpell;}
        public int getPowerPlayerSpell() { return powerPlayerSpell; }

        public int getSumPowerPlayer(){ return sumPowerPlayer; }
        public int getSumPowerEnemy(){ return sumPowerEnemy; }


        public void setPowerCreaturePlayer(int powerCreature) 
        { 
            powerPlayerCreature = powerCreature;
            updatePowerPlayers();
        }

        public void setPowerCreatureEnemy(int powerCreature)
        {
            powerEnemyCreature = powerCreature;
            updatePowerPlayers();
        }

        public void addPowerCreaturePlayer(int powerCreature) 
        {
            powerPlayerCreature += powerCreature;
            updatePowerPlayers();
        }

        public void addPowerCreatureEnemey(int powerCreature)
        { 
            powerEnemyCreature += powerCreature;
            updatePowerPlayers();
        }

        public void removeCreaturePowerPlayer(int powerCreature)
        {
            powerPlayerCreature -= powerCreature;
            updatePowerPlayers();
        }

        public void removeCreaturePowerEnemy(int powerCreature)
        {
            powerEnemyCreature -= powerCreature;
            updatePowerPlayers();
        }


        //Spell
        public void setPowerSpellPlayer(int powerSpell)
        {
            powerPlayerSpell = powerSpell;
        }

        public void setPowerSpellEnemy(int powerSpell)
        {
            powerEnemySpell = powerSpell;
        }

        public void addPowerSpellPlayer(int powerSpell)
        {
            powerPlayerSpell += powerSpell; 
            updatePowerPlayers(); 
                   
        }

        public void addPowerSpellEnemy(int powerSpell)
        {
            powerEnemySpell += powerSpell;
            updatePowerPlayers();
        }

        public void removePowerSpellPlayer(int powerSpell)
        {
            powerPlayerSpell -= powerSpell;
            updatePowerPlayers();
        }    

        public void removePowerSpellEnemy(int powerSpell)
        {
            powerEnemySpell -= powerEnemySpell;
            updatePowerPlayers();
        }






        public void resetPowerPlayers()
        {
            refreshPlayer();
            refreshEnemy();
        }

        public void refreshPlayer()
        {
            powerPlayerCreature = 0;
            updatePowerPlayers();
        }    

        public void refreshEnemy()
        {
            powerEnemyCreature = 0;
            updatePowerPlayers();
        }



        private void updatePowerPlayers()
        {
            sumPowerEnemy = powerEnemyCreature + powerEnemySpell;
            sumPowerPlayer = powerPlayerCreature + powerPlayerSpell;

        }




    }
}