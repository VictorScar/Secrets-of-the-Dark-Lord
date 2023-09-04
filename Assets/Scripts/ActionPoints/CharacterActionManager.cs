using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SODL.Character;
using System;
using Random = UnityEngine.Random;
using SODL.DiceRoll;
using SODL.Core;

namespace SODL.ActionPoints
{
    public class CharacterActionManager : MonoBehaviour
    {
        [SerializeField] CharacterActionConfig characterActionConfig;
        GameCharacter turnOwner;
        DiceRollManager diceRollManager;
        public int ActionPointCount { get; private set; }

        public event Action onCharacterFinished;
        public event Action onActionPointsChanged;

        private void Awake()
        {
            diceRollManager = Game.Instance.DiceRollManager;
            Debug.Log(diceRollManager);
        }

        public bool CanDoAction(CharacterActionType action)
        {
            var actionInfo = characterActionConfig.GetInfo(action);

            return CanDoAction(actionInfo);
        }

        public bool CanDoAction(CharacterActionInfo actionInfo)
        {
            if (actionInfo != null && ValidateItem(actionInfo) && ValidatePoints(actionInfo))
            {
                return true;
            }
            return false;
        }

        public bool DoAction(CharacterActionType action)
        {
            var actionInfo = characterActionConfig.GetInfo(action);

            if (CanDoAction(actionInfo))
            {
                ActionPointCount -= actionInfo.RequiredPoints;
                onActionPointsChanged?.Invoke();
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
            this.turnOwner = turnOwner;
            diceRollManager.onDiceRollEnded += UpdateValues;
            diceRollManager.StartDiceRolling();
        }

        void UpdateValues(int actionPoints)
        {
            ActionPointCount = actionPoints;
            diceRollManager.onDiceRollEnded -= UpdateValues;
            onActionPointsChanged?.Invoke();
        }

        public void FinishTurn()
        {
            onCharacterFinished?.Invoke();
        }
    }
}