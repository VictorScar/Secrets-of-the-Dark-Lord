using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterInput : MonoBehaviour
{
    [SerializeField] protected Player player;

    void Update()
    {
        if (!player.IsMoving)
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
