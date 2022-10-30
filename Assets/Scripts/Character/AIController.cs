using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] GameCharacter character;
        Vector3 characterDirection;

        private void Start()
        {
            characterDirection = character.transform.forward;
        }

        void DetermineDirection()
        {
            if (characterDirection == Vector3.forward)
            {
                character.Move(MoveDirection.Up);
            }
            else if (characterDirection == -Vector3.forward)
            {
                character.Move(MoveDirection.Down);
            }
            else if (characterDirection == Vector3.right)
            {
                character.Move(MoveDirection.Right);
            }
            else if (characterDirection == Vector3.left)
            {
                character.Move(MoveDirection.Left);
            }
        }

        void RotateCharacter()
        {
            if (character.CurrentCell.OnBeforeCharacterMove(character))
            {
                character.transform.Rotate(0, 90, 0);
            }
        }

        void FindPlayer()
        {
            List<GameCharacter> characters = character.CurrentCell.CharactersOnCell;
            foreach (GameCharacter character in characters)
            {
                if (character is Player)
                {

                    break;
                }
            }

        }
    }
}