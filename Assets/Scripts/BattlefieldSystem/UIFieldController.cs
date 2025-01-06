using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.BattlefieldSystem
{
    public class UIFieldController : MonoBehaviour
    {

        [SerializeField] TMP_Text textPlayerCountPowerCard;
        [SerializeField] TMP_Text textEnemyCountPowerCard;

        [SerializeField] Transform playerPlaceSpell;
        [SerializeField] Transform enemyPlaceSpell;

        private CreateCard createCard;

        private List<CardManager> playerSpellCards = new List<CardManager>();
        private List<CardManager> enemySpellCards = new List<CardManager>();


        [SerializeField] Image damageIcone;

        [SerializeField] Transform playerPlaceDamageIcone;
        [SerializeField] Transform enemyPlaceDamageIcone;

        private List<Image> playerDamageIcones = new List<Image>();
        private List<Image> enemyDamageIcones = new List<Image>();

        private void Start()
        {
            createCard = new CreateCard();
        }

        // damage icone ui
        public void setPlayerDamageStatus(int index)
        {
            resetPlayerDamageStatus();

            for (int i = 0; i < index; i++)
            {
                playerDamageIcones.Add(Instantiate(damageIcone, playerPlaceDamageIcone));
            }

        }

        public void setEnemyDamageStatus(int index)
        {

            resetEnemyDamageStatus();

            for (int i = 0; i < index; i++)
            {
                enemyDamageIcones.Add(Instantiate(damageIcone, enemyPlaceDamageIcone));
            }

        }

        private void resetPlayerDamageStatus()
        {
            if (playerDamageIcones.Count > 0)
            {
                for (int i = 0; i < playerDamageIcones.Count; i++)
                {
                    Destroy(playerDamageIcones[i]);
                    playerDamageIcones.RemoveAt(i);
                }

            }
            else
            {
                Debug.Log("not enought ui Damage Image to delete");
            }

        }

        private void resetEnemyDamageStatus()
        {
            if (enemyDamageIcones.Count > 0)
            {
                for (int i = 0; i < enemyDamageIcones.Count; i++)
                {
                    Destroy(enemyDamageIcones[i]);
                    enemyDamageIcones.RemoveAt(i);
                }

            }
            else
            {
                Debug.Log("not enought ui Damage Image to delete");
            }

        }


        // set player spell UI
        public Transform setPlayerSpell()
        {
            return playerPlaceSpell;
        }

        public Transform setEnemySpell()
        {
            return playerPlaceSpell; // change s[ell place for enemy
        }

        public void resetPlayerSpell(int index)
        {
            if (playerSpellCards.Count > 0)
            {
                Destroy(playerSpellCards[index]);
                playerSpellCards.RemoveAt(index);
            }
            else
            {
                Debug.Log("not enought ui spell card to delete");
            }

        }

        public void resetEnemySpell(int index)
        {
            if (enemySpellCards.Count > 0)
            {
                Destroy(enemySpellCards[index]);
                enemySpellCards.RemoveAt(index);
            }
            else
            {
                Debug.Log("not enought ui spell card to delete");
            }

        }


        public void resetPlayersSpells()
        {
            while (enemySpellCards.Count > 0 || playerSpellCards.Count > 0)
            {
                resetEnemySpell(0);
                resetPlayerSpell(0);
            }

        }


        // text power card players TMPro
        public void changePlayerPowerText(int power)
        {
            textPlayerCountPowerCard.text = power.ToString();
        }

        public void changeEnemyPowerText(int power)
        {
            textPlayerCountPowerCard.text = power.ToString();
        }

        public void resetPowerText()
        {
            changePlayerPowerText(0);
            changeEnemyPowerText(0);

        }


    }

}
