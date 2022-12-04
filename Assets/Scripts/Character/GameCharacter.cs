using SODL.ActionPoints;
using SODL.Cells;
using SODL.Core;
using SODL.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    [SelectionBase]
    public class GameCharacter : MonoBehaviour
    {
        public Cell startingCell;
        private Cell currentCell;
        [SerializeField] bool canPickupItems = false;
        public bool IsMoving { get; private set; }
        [SerializeField] CharacterInventory inventory;
        public CharacterInventory Inventory { get => inventory; }
        public int Health { get; set; } = 1;
        public float Attack { get; set; } = 1;
        public float Defenence { get; set; } = 1;
        public Cell CurrentCell { get => currentCell; }
        public MoveDirection LastMoveDirection { get; private set; }
        public MoveDirection CharacterDirection { get; private set; }
        public bool CanPickupItems { get => canPickupItems; private set => canPickupItems = value; }

        [SerializeField] protected float speed = 0.5f;
        [SerializeField] protected Animator animator;
        CharacterActionManager actionManager;

        protected virtual void Awake()
        {
            RotateTo(MoveDirection.Up);
        }

        protected virtual void Start()
        {
            currentCell = startingCell;
            actionManager = Game.Instance.ActionManager;
            Game.Instance.TurnManager.RegisterCharacter(this);
            //Debug.Log("Start");
        }

        public void Move(MoveDirection direction)
        {
            StartCoroutine(MoveCoroutine(direction));
        }

        IEnumerator MoveCoroutine(MoveDirection direction)
        {
            IsMoving = true;
            if (animator!= null) animator.Play("Run");

            Cell nextCell = null;
            switch (direction)
            {
                case MoveDirection.Up:
                    nextCell = currentCell.GetUpperCell();
                    break;
                case MoveDirection.Down:
                    nextCell = currentCell.GetBottomCell();
                    break;
                case MoveDirection.Left:
                    nextCell = currentCell.GetLeftCell();
                    break;
                case MoveDirection.Right:
                    nextCell = currentCell.GetRightCell();
                    break;
            }


            //Проверка условий возможности перехода на ячейку в заданном направлении.
            //Существует ли данная ячейка?
            //Достаточно ли очков действия для перехода на нее?

            if (nextCell != null && actionManager.DoAction(nextCell.ActionType))


            {
                RotateTo(direction);

                //Можно ли на нее встать персонажем?
                if (nextCell.OnBeforeCharacterMove(this))
                {
                    //анимация перемещения персонажа
                    yield return PlayMoveAnimation(nextCell);

                    //сохранение информации о положении и последнем перемещении персонажа
                    currentCell.OnCharacterLeave(this);
                    currentCell = nextCell;
                    LastMoveDirection = direction;

                    //Уведомление ячейки, что игрок находится на ней
                    nextCell.OnCharacterEnter(this);
                }
            }

            IsMoving = false;
            if (animator != null) animator.Play("Idle");

        }

        private void TeleportToCell(Cell nextCell)
        {
            transform.position = nextCell.transform.position;
            currentCell = nextCell;
        }

        public void RotateTo(MoveDirection direction)
        {
            CharacterDirection = direction;
            transform.rotation = (direction) switch
            {
                MoveDirection.Up => Quaternion.identity,
                MoveDirection.Down => Quaternion.Euler(0, 180, 0),
                MoveDirection.Left => Quaternion.Euler(0, -90, 0),
                MoveDirection.Right => Quaternion.Euler(0, 90, 0),
                _ => transform.rotation
            };
        }

        public virtual void AddItem(Item item, int count)
        {
            Inventory.AddItem(item, count);
        }

        IEnumerator PlayMoveAnimation(Cell nextCell)
        {
            //TODO: Переделать в дотвин

            while (transform.position != nextCell.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCell.transform.position, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}