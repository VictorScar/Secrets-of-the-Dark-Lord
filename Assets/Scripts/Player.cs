using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour
{
    public Cell startingCell;
    Cell currentCell;
    enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }



    void Start()
    {
        currentCell = startingCell;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(MoveDirection.Up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(MoveDirection.Down);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(MoveDirection.Left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(MoveDirection.Right);
        }
    }

    private void Move(MoveDirection direction)
    {
       
        Cell nextCell = null;
        switch (direction)
        {
            case MoveDirection.Up:
                nextCell = currentCell.GetUpperCell();
                gameObject.transform.rotation = Quaternion.identity;
                break;
            case MoveDirection.Down:
                nextCell = currentCell.GetBottomCell();
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case MoveDirection.Left:
                nextCell = currentCell.GetLeftCell();
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
            case MoveDirection.Right:
                nextCell = currentCell.GetRightCell();
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }

        if (nextCell is Floor)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nextCell.transform.position, 1);
            currentCell = nextCell;

        }
        else if (nextCell is Door)
        {
            Door door = nextCell as Door;
            if (door.opened)
            {
                gameObject.transform.position = nextCell.transform.position;
                currentCell = nextCell;

            }
            else
            {
                Debug.Log("Door is lock");
                door.OpenDoor();
            }

        }
    }
}
