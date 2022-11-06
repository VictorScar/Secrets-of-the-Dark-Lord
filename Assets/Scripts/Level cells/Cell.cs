using SODL.ActionPoints;
using SODL.Character;
using SODL.Core;
using SODL.Utils;
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
        List<GameCharacter> charactersOnCell;

        public Map Map { get { return map; } }

        public CharacterActionType ActionType { get => actionType; protected set => actionType = value; }
        public List<GameCharacter> CharactersOnCell { get => charactersOnCell; }

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

        public Cell GetCellByDirection(Direction direction)
        {
            return direction switch
            {
                Direction.None => this,
                Direction.Up => GetUpperCell(),
                Direction.Down => GetBottomCell(),
                Direction.Left => GetLeftCell(),
                Direction.Right => GetRightCell(),
                _ => throw new NotImplementedException(),
            };
        }

        public void AddCharactrOnCell(GameCharacter character)
        {
            charactersOnCell.Add(character);
        }

        public void RemoveCharactrOnCell(GameCharacter character)
        {
            charactersOnCell.Remove(character);
        }
    }
}