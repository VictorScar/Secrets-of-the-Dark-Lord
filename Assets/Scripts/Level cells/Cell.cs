using SODL.ActionPoints;
using SODL.Character;
using SODL.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Cells
{
    [SelectionBase]
    public class Cell : MonoBehaviour
    {
        protected Map map;
        public Vector2Int coord;
        [SerializeField] private CharacterActionType actionType;

        public Map Map { get { return map; } }

        public CharacterActionType ActionType { get => actionType; }

        public virtual void Init(Map map)
        {
            this.map = map;
        }

        public virtual bool OnBeforeCharacterMove(GameCharacter character)
        {
            return false;
        }

        public virtual void OnCharacterMove(GameCharacter character)
        {

        }

        public Cell GetBottomCell()
        {
            return map.GetBottomCell(this);
        }

        public Cell GetUpperCell()
        {

            return map.GetUpperCell(this);
        }

        public Cell GetLeftCell()
        {

            return map.GetLeftCell(this);
        }

        public Cell GetRightCell()
        {

            return map.GetRightCell(this);
        }

    }
}