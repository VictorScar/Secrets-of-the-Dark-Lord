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
        protected Cell currentCell;
        public bool IsMoving { get; private set; }
        [SerializeField] CharacterInventory inventory;
        public CharacterInventory Inventory { get => inventory; }
        [SerializeField] protected float speed = 0.5f;
        [SerializeField] protected Animator animator;
        CharacterActionManager actionManager;

        private void Start()
        {
            currentCell = startingCell;
            actionManager = Game.Instance.ActionManager;
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
                      
            if (nextCell != null && actionManager.DoAction(nextCell.ActionType) && nextCell.OnBeforeCharacterMove(this))
            {
                yield return PlayMoveAnimation(nextCell);
                nextCell.OnCharacterMove(this);
            }

            IsMoving = false;
            animator.Play("Idle");
        }

        private void TeleportToCell(Cell nextCell)
        {
            transform.position = nextCell.transform.position;
            currentCell = nextCell;
        }

        IEnumerator PlayMoveAnimation(Cell nextCell)
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
}