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
        [SerializeField]protected List<GameCharacter> charactersOnCell = new List<GameCharacter>();

        public Map Map { get { return map; } }

        public CharacterActionType ActionType { get => actionType; protected set => actionType = value; }
        public List<GameCharacter> CharactersOnCell { get => charactersOnCell; }

        public event Action<GameCharacter> onCharacterEnter;
        public event Action<GameCharacter> onCharacterLeave;

        public virtual void Init(Map map) => this.map = map;
        public virtual bool OnBeforeCharacterMove(GameCharacter character) => true;

        public virtual void OnCharacterEnter(GameCharacter character)
        {
            charactersOnCell.Add(character);
            onCharacterEnter?.Invoke(character);
        }

        public virtual void OnCharacterLeave(GameCharacter character)
        {
            charactersOnCell.Remove(character);
            onCharacterLeave?.Invoke(character);
        }

        public Cell GetBottomCell() => map.GetBottomCell(this);
        public Cell GetUpperCell() => map.GetUpperCell(this);
        public Cell GetLeftCell() => map.GetLeftCell(this);
        public Cell GetRightCell() => map.GetRightCell(this);

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
    }
}