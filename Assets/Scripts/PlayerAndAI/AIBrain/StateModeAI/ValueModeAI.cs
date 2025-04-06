using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.PlayerAndAI.AIBrain.StateModeAI
{
    public class ValueModeAI : IBotModeState
    {

        public void EnterMode(AiBrainManager brain)
        {
            Debug.Log("Enter Mode ValueMode");

            brain.updateHandCards();


            if(brain.hasCreaturesHand())
            {

                if (brain.countCreaturesThanSpells())
                {
                    List<CardData> powerCreaturesPool = brain.getCardsStrongerThanOpponent();

                    if (powerCreaturesPool.Count > 0)
                    {
                        CardData weakleCard = brain.getWeakleCard(powerCreaturesPool);
                        brain.getHandCardManagerByData(weakleCard).tryPlayCard();
                        return;
                    }  

                }

                if (brain.isPlaingSpellCreatureComboLogic())
                {
                    return;
                }

            }    

            


            if (brain.isDrawCardDeck())
            {
                brain.drawCardLogic();
                brain.setBotMode();
                return;
            }


            brain.findPlaingSpell();
            return; 


        }

        public void ExiteMode(AiBrainManager aiBrain)
        {
            Debug.Log("Exit Mode ValueMode");
        }





    }
}