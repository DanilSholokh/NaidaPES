using UnityEngine;

namespace Assets.Scripts.BattlefieldSystem
{
    public class CalculateFieldRule : MonoBehaviour
    {

        int powerPlayer = 0;
        int powerEnemy = 0;



        public int getPowerPlayer() { return powerPlayer; }
        public int getPowerEnemy() { return powerEnemy; }


        public void setPowerPlayer(int powerCard) 
        { 
            powerPlayer = powerCard; 
        }

        public void setPowerEnemy(int powerCard)
        {
            powerEnemy = powerCard;
        }

        public void addPowerPlayer(int powerCard) 
        {
            powerPlayer += powerCard;
        }

        public void addPowerEnemey(int powerCard)
        { 
            powerEnemy += powerCard;
        }

        public void removePowerPlayer(int powerCard)
        {
            powerPlayer -= powerCard;
        }

        public void removePowerEnemy(int powerCard)
        {
            powerEnemy -= powerCard;
        }

    }
}