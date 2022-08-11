using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : CharacterInput
{
    protected override MoveDirection GetCommand()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return MoveDirection.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return MoveDirection.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return MoveDirection.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return MoveDirection.Right;
        }
        else
        {
            return MoveDirection.None;
        }
    }
}
