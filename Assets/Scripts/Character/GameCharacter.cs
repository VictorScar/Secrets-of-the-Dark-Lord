using SODL.ActionPoints;
using SODL.Cells;
using SODL.Core;
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
        public bool IsMoving { get; private set; }
        [SerializeField] CharacterInventory inventory;
        public CharacterInventory Inventory { get => inventory; }
        public int Health { get; set; } = 1;
        public float Attack { get; set; } = 1;
        public float Defenence { get; set; } = 1;
        public Cell CurrentCell { get => currentCell; }
        public MoveDirection LastMoveDirection { get; private set; } = MoveDirection.None;


        [SerializeField] protected float speed = 0.5f;
        [SerializeField] protected Animator animator;
        bool isReady { get; set; } = false;
        CharacterActionManager actionManager;

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {
            currentCell = startingCell;
            actionManager = Game.Instance.ActionManager;
            Game.Instance.TurnManager.RegisterCharacter(this);
            actionManager.onActionPointsOut += ActionsEnded;
        }

        public void Move(MoveDirection direction)
        {
            if (isReady == true)
            {
                StartCoroutine(MoveCoroutine(direction));
            }
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
                    currentCell = nextCell;
                    LastMoveDirection = direction;

                    //Уведомление ячейки, что игрок находится на ней
                    nextCell.OnCharacterMove(this);
                }
            }

            IsMoving = false;
            animator.Play("Idle");

        }

        private void TeleportToCell(Cell nextCell)
        {
            transform.position = nextCell.transform.position;
            currentCell = nextCell;
        }

        void ActionsEnded()
        {
            isReady = false;
        }

        public void RotateTo(MoveDirection direction)
        {
            transform.rotation = (direction) switch
            {
                MoveDirection.Up => Quaternion.identity,
                MoveDirection.Down => Quaternion.Euler(0, 180, 0),
                MoveDirection.Left => Quaternion.Euler(0, -90, 0),
                MoveDirection.Right => Quaternion.Euler(0, 90, 0),
                _ => transform.rotation
            };
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