using SODL.ActionPoints;
using SODL.Cells;
using SODL.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class NPCCharacter : GameCharacter
    {
        [SerializeField] AIController controller;
        public bool CanMoveToDirection(MoveDirection direction)
        {
            Cell nextCell = CurrentCell.GetCellByDirection(direction.ToDirectionType());
            if (nextCell.ActionType == CharacterActionType.None)
            {
                return false;
            }
            return true;
        }

        public void InitTurn()
        {
            StartCoroutine(controller.Wandering());
        }
    }
}