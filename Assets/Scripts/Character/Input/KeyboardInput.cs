using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace SODL.Character.Input
{
    public class KeyboardInput : CharacterInput
    {
        protected override MoveDirection GetCommand()
        {

            if (UnityInput.GetKeyDown(KeyCode.UpArrow))
            {
                return MoveDirection.Up;
            }
            else if (UnityInput.GetKeyDown(KeyCode.DownArrow))
            {
                return MoveDirection.Down;
            }
            else if (UnityInput.GetKeyDown(KeyCode.LeftArrow))
            {
                return MoveDirection.Left;
            }
            else if (UnityInput.GetKeyDown(KeyCode.RightArrow))
            {
                return MoveDirection.Right;
            }
            else
            {
                return MoveDirection.None;
            }
        }
    }
}