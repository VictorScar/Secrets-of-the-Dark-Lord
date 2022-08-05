using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour
{
    [SerializeField] Animator animatorPlayer;
    public Cell startingCell;
    Cell currentCell;
    float speed = 0.5f;
    enum Direction
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
            Move(Direction.Up);
            
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Direction.Down);
           
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Direction.Right);
            
        }
    }

    private void Move(Direction direction)
    {
        animatorPlayer.Play("Run");
        Cell nextCell = null;
        switch (direction)
        {
            case Direction.Up:
                nextCell = currentCell.GetUpperCell(currentCell);
                gameObject.transform.rotation = Quaternion.identity;
                break;
            case Direction.Down:
                nextCell = currentCell.GetBottomCell(currentCell);
                gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                break;
            case Direction.Left:
           nextCell = currentCell.GetLeftCell(currentCell);
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
            case Direction.Right:
                nextCell = currentCell.GetRightCell(currentCell);
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
      
        if (nextCell is Floor)
        {
            gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, nextCell.transform.position, 1);
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
        animatorPlayer.Play("Idle");
    }
}
