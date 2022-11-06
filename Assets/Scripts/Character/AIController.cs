using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] GameCharacter character;
        MoveDirection characterDirection;

        private void Start()
        {
            characterDirection = MoveDirection.Right;  //.Random.Range(1, 4);//MoveDirection.Down;
            //TODO: var values = Enum.GetValues(typeof(MoveDirection));
        }

        private void Update()
        {
            //character.transform.rotation.SetLookRotation(Vector3.right);
            //character.Move(characterDirection);
        }

        void DetermineDirection()
        {
            if (characterDirection == MoveDirection.Up)
            {
                character.Move(MoveDirection.Up);
            }
            else if (characterDirection == MoveDirection.Down)
            {
                character.Move(MoveDirection.Down);
            }
            else if (characterDirection == MoveDirection.Right)
            {
                character.Move(MoveDirection.Right);
            }
            else if (characterDirection == MoveDirection.Left)
            {
                character.Move(MoveDirection.Left);
            }
            else Debug.LogError($"Направление: {characterDirection} не обрабатывается. Поворот должен быть кратным 90 градусов");
            //Первоочередно - направление, а не поворот объекта.
            //Необходимо задавать направление и поворачивать объект по нему, а не наоборот
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