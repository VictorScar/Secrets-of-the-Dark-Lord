using SODL.ActionPoints;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character.Input
{
    public abstract class CharacterInput : MonoBehaviour
    {
        [SerializeField] protected Player player;
        TurnManager turnManager;

        private void Start()
        {
            turnManager = Game.Instance.TurnManager;
        }

        void Update()
        {
            if (player == turnManager.TurnOwner && !player.IsMoving)
            {
                MoveDirection direction = GetCommand();
                if (direction != MoveDirection.None)
                {
                    player.Move(direction);
                }

            }
        }

        protected abstract MoveDirection GetCommand();

        private void Reset()
        {
            player = GetComponent<Player>();
        }
    }
}