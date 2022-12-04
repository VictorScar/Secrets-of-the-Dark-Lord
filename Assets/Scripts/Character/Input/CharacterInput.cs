using SODL.ActionPoints;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character.Input
{
    public abstract class CharacterInput : MonoBehaviour
    {
        [SerializeField] protected GameCharacter character;
        TurnManager turnManager;

        private void Start()
        {
            turnManager = Game.Instance.TurnManager;
        }

        void Update()
        {
            if (character == turnManager.TurnOwner && !character.IsMoving)
            {
                MoveDirection direction = GetCommand();
                if (direction != MoveDirection.None)
                {
                    character.Move(direction);
                }
            }
        }

        protected abstract MoveDirection GetCommand();

        private void Reset()
        {
            character = GetComponent<GameCharacter>();
        }
    }
}