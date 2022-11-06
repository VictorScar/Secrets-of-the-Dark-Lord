using SODL.Character;
using System;

namespace SODL.Utils
{
    public static class Extensions
    {
        public static Direction ToDirection(this MoveDirection moveDirection)
        {
            return moveDirection switch
            {
                MoveDirection.Up => Direction.Up,
                MoveDirection.Down => Direction.Down,
                MoveDirection.Left => Direction.Left,
                MoveDirection.Right => Direction.Right,
                MoveDirection.None => Direction.None,
                _ => throw new ArgumentException()
            };
        }

        public static MoveDirection Inverse(this MoveDirection moveDirection)
        {
            return moveDirection switch
            {
                MoveDirection.Up => MoveDirection.Down,
                MoveDirection.Down => MoveDirection.Up,
                MoveDirection.Left => MoveDirection.Right,
                MoveDirection.Right => MoveDirection.Left,
                MoveDirection.None => MoveDirection.None,
                _ => throw new ArgumentException()
            };
        }
    }
}
