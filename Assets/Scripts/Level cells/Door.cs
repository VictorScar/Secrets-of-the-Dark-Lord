using SODL.Character;
using SODL.Core;
using UnityEngine;

namespace SODL.Cells
{
    public class Door : Cell
    {
        public bool Opened { get; protected set; }
        private bool haveEvent = true;

        [SerializeField] Animator doorAnimator;

        public override void Init(Map map)
        {
            base.Init(map);
            OrientDoor();
        }

        private void OrientDoor()
        {
            if (GetBottomCell() is Floor)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        public void OpenDoor()
        {
            Opened = true;
            doorAnimator.Play("Open");
            ActionType = ActionPoints.CharacterActionType.MoveToCell;
        }
        public void CloseDoor()
        {
            Opened = false;
            doorAnimator.Play("Closed");
        }

        public override bool OnBeforeCharacterMove(GameCharacter character)
        {
            if (!Opened)
            {
                OpenDoor();
                return false;
            }
            return true;
        }

        public override void OnCharacterMove(GameCharacter character)
        {
            if (haveEvent)
            {
                Game.Instance.RoomEventManager.StartRandomEvent();
                haveEvent = false;
            }
        }
    }
}