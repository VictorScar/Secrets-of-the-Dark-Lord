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
        [SerializeField] NPCCharacter npcCharacter;
        CharacterActionManager actionManager;
        //MoveDirection characterDirection;
        TurnManager turnManager;
        MoveDirection[] directions = (MoveDirection[])Enum.GetValues(typeof(MoveDirection));

        private void Start()
        {
            turnManager = Game.Instance.TurnManager;
            actionManager = Game.Instance.ActionManager;
            //characterDirection = DetermineInitialeDirection();
        }

        MoveDirection DetermineInitialeDirection()
        {
            //MoveDirection[] directions = (MoveDirection[])Enum.GetValues(typeof(MoveDirection));
            return directions[UnityEngine.Random.Range(1, 5)];
            //TODO: fix
        }


        void FindPlayer()
        {
            Cell cellForVerification = npcCharacter.CurrentCell;
            //MoveDirection[] directions = (MoveDirection[])Enum.GetValues(typeof(MoveDirection));

            foreach (MoveDirection direction in directions)
            {
                cellForVerification = cellForVerification.GetCellByDirection(direction.ToDirectionType());
                //TODO: Исправить ячейку отсчета
                List<GameCharacter> charactersOnCell = cellForVerification.CharactersOnCell;

                if (charactersOnCell != null)
                {
                    foreach (GameCharacter character in charactersOnCell)
                    {
                        if (character is not NPCCharacter)
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
                //yield return npcCharacter.MoveCoroutine(characterDirection);
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