using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Player : MonoBehaviour
{
    public Cell startingCell;
    Cell currentCell;
    [SerializeField] float speed = 0.5f;

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
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(MoveDirection.Down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(MoveDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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

        if (nextCell != null && nextCell.OnBeforePlayerMove(this))
        {
            //TeleportToCell(nextCell);
            StartCoroutine(MoveToCell(nextCell));
            currentCell = nextCell;
            nextCell.OnPlayerMove(this);
        }
    }

    private void TeleportToCell(Cell nextCell)
    {
        transform.position = nextCell.transform.position;
        currentCell = nextCell;
    }

    IEnumerator MoveToCell(Cell nextCell)
    {
        int time = 360;
        while (time<0)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0,0);
            time--;
            
        }
        currentCell = nextCell;
        yield return null;
    }
}
