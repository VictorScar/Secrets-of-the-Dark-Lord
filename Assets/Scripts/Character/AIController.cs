using SODL.ActionPoints;
using SODL.Cells;
using SODL.Core;
using SODL.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] EnemyCharacter npcCharacter;
        CharacterActionManager actionManager;
        TurnManager turnManager;
        MoveDirection[] directions = (MoveDirection[])Enum.GetValues(typeof(MoveDirection));

        private void Start()
        {
            turnManager = Game.Instance.TurnManager;
            actionManager = Game.Instance.ActionManager;
        }

        void FindPlayer()
        {
            Cell cellForVerification = npcCharacter.CurrentCell;

            foreach (MoveDirection direction in directions)
            {
                cellForVerification = cellForVerification.GetCellByDirection(direction.ToDirectionType());
                //TODO: Исправить ячейку отсчета
                List<GameCharacter> charactersOnCell = cellForVerification.CharactersOnCell;

                if (charactersOnCell != null)
                {
                    foreach (GameCharacter character in charactersOnCell)
                    {
                        if (character is not EnemyCharacter)
                        {
                            Debug.Log("Fight!");
                        }
                    }
                }
            }
        }

        MoveDirection DetermineDirection()
        {
            MoveDirection characterDirection = npcCharacter.CharacterDirection;
            for (int i = 0; i < 4; i++)
            {
                if (npcCharacter.CanMoveToDirection(characterDirection))
                {
                    return characterDirection;
                }
                characterDirection = characterDirection.GetRotatedLeft();
            }
            return MoveDirection.None;
        }

        IEnumerator DoStep()
        {
            MoveDirection moveDirection = DetermineDirection();
            if (moveDirection != MoveDirection.None)
            {
                npcCharacter.Move(moveDirection);
                yield return new WaitWhile(() => npcCharacter.IsMoving);
                FindPlayer();
            }
        }

        public IEnumerator Wandering()
        {
            while (actionManager.ActionPointCount > 0)
            {
                yield return DoStep();
            }

            Game.Instance.ActionManager.FinishTurn();

        }
    }
}