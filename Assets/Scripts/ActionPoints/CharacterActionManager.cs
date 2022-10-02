using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SODL.Character;
using System;
using Random = UnityEngine.Random;

namespace SODL.ActionPoints
{
    public class CharacterActionManager : MonoBehaviour
    {
        //[SerializeField] TurnManager turnManager;
        [SerializeField] CharacterActionConfig characterActionConfig;
        GameCharacter turnOwner;
        public int ActionPointCount { get ; private set; }

        public event Action onCharacterFinished;
        public event Action onActionPointsChanged;

        public bool CanDoAction(CharacterActionType action)
        {
            var actionInfo = characterActionConfig.GetInfo(action);
            if (actionInfo !=null)
            {
                if (actionInfo.RequiredItem!=null)
                {
                    
                }
            }
            return true;

            //Dictionary<CharacterActionType, int> actions = new Dictionary<CharacterActionType, int>();
            //int requiredPoints = actions.GetValueOrDefault(action);

            //if (ActionPointCount >= requiredPoints)
            //{
            //    ActionPointCount -= requiredPoints;
            //    return true;
            //}
            //return false;
        }

        public void StartNewTurn(GameCharacter turnOwner)
        {
            ActionPointCount = Random.Range(0, 7);
            this.turnOwner = turnOwner;
        }
    }
}