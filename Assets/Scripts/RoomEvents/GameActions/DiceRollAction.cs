using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.RoomEvents
{
    [System.Serializable]
    public class DiceRollAction : IGameAction
    {
        [SerializeReference, SubclassSelector] IGameAction successfulAction;
        [SerializeReference, SubclassSelector] IGameAction failedAction;
        [SerializeField] int minSuccessfulValue = 4;

        public void Run()
        {
            int diceValue = Random.Range(1, 7);

            if (diceValue >= minSuccessfulValue) successfulAction.Run();
            else failedAction.Run();
        }
    }
}