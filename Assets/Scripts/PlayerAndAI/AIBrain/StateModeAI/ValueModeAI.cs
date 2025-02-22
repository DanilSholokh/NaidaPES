using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerAndAI.AIBrain.StateModeAI
{
    public class ValueModeAI : IBotModeState
    {
        public void EnterMode(AiBrainManager aiBrain)
        {
            Debug.Log("Enter Mode ValueMode");
            aiBrain.initBotData();
        }

        public void ExiteMode(AiBrainManager aiBrain)
        {
            Debug.Log("Exit Mode ValueMode");
            throw new System.NotImplementedException();
        }
    }
}