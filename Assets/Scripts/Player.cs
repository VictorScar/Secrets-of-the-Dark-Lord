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
    [SerializeField] Animator animator;
    [SerializeField] Inventory inventory;

    public bool IsMoving { get; private set; }
    public Inventory Inventory { get => inventory; }

    void Awake()
    {
        Game.Instance.Player = this;
    }

    private void Start()
    {
        currentCell = startingCell;
    }

    public void Move(MoveDirection direction)
    {
        StartCoroutine(MoveCoroutine(direction));
    }

    IEnumerator MoveCoroutine(MoveDirection direction)
    {
        IsMoving = true;
        animator.Play("Run");

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
            yield return MoveToCell(nextCell);
            nextCell.OnPlayerMove(this);
        }

        IsMoving = false;
        animator.Play("Idle");
    }

    private void TeleportToCell(Cell nextCell)
    {
        transform.position = nextCell.transform.position;
        currentCell = nextCell;
    }

    IEnumerator MoveToCell(Cell nextCell)
    {
        //TODO: Переделать в дотвин

        while (transform.position != nextCell.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextCell.transform.position, speed * Time.deltaTime);
            yield return null;

        }
        currentCell = nextCell;
    }
}
