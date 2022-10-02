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
        public int ActionPointCount { get; private set; }

        public event Action onCharacterFinished;
        public event Action onActionPointsChanged;

        public bool DoAction(CharacterActionType action)
        {
            var actionInfo = characterActionConfig.GetInfo(action);

            if (actionInfo != null && ValidateItem(actionInfo) && ValidatePoints(actionInfo))
            {
                ActionPointCount -= actionInfo.RequiredPoints;
                return true;
            }

            return false;
        }

        private bool ValidateItem(CharacterActionInfo info)
        {
            if (info.RequiredItem != null)
            {
                return turnOwner.Inventory.HasItem(info.RequiredItem);
            }

            return true;
        }

        private bool ValidatePoints(CharacterActionInfo info)
        {
            return (ActionPointCount >= info.RequiredPoints);
        }

        public void StartNewTurn(GameCharacter turnOwner)
        {
            ActionPointCount = Random.Range(0, 7);
            this.turnOwner = turnOwner;
        }
    }
}