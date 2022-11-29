using SODL.ActionPoints;
using SODL.Character;
using SODL.Core;
using SODL.UI;
using UnityEngine;

namespace SODL.Cells
{
    public class Door : Cell
    {
        public bool Opened { get; protected set; }
        private bool haveEvent = true;
        [SerializeField] Floor[] floorsNear = new Floor[2];

        [SerializeField] Animator doorAnimator;
        DoorUIPool doorUIPool;
        DoorUI doorUI;
        [SerializeField] CharacterActionType specialActionType;

        public override void Init(Map map)
        {
            base.Init(map);
            OrientDoor();
            doorUIPool = Game.Instance.DoorUIPool;
            StartPlayerTracking();
        }

        private void OrientDoor()
        {
            if (GetBottomCell() is Floor bottomCell)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                floorsNear[0] = bottomCell;
                floorsNear[1] = GetUpperCell() as Floor;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                floorsNear[0] = GetLeftCell() as Floor;
                floorsNear[1] = GetRightCell() as Floor;
            }

        }

        void StartPlayerTracking()
        {
            floorsNear[0].onCharacterEnter += OnCharacterNearEnter;
            floorsNear[0].onCharacterLeave += OnCharacterNearLeave;
            floorsNear[1].onCharacterEnter += OnCharacterNearEnter;
            floorsNear[1].onCharacterLeave += OnCharacterNearLeave;
        }

        void OnCharacterNearEnter(GameCharacter character)
        {
            if (character is not EnemyCharacter)
            {
                ShowDoorUI();
            }
        }

        private void ShowDoorUI()
        {
            doorUI = doorUIPool.GetDoorUI();
            if (doorUI != null)
            {
                doorUI.Init(this, specialActionType);
            }
        }

        void OnCharacterNearLeave(GameCharacter character)
        {
            if (character is not EnemyCharacter)
            {
                HideDoorUI();
            }
        }

        private void HideDoorUI()
        {
            doorUI.Finish();
            doorUIPool.ReturnDoorUI(doorUI);
            doorUI = null;
        }

        public void OpenDoor()
        {
            Opened = true;
            doorAnimator.Play("Open");
            ActionType = ActionPoints.CharacterActionType.MoveToCell;
            HideDoorUI();
            StopPlayerTracking();
        }

        public void CloseDoor()
        {
            Opened = false;
            doorAnimator.Play("Closed");
        }

        public override void OnCharacterEnter(GameCharacter character)
        {
            base.OnCharacterEnter(character);
            if (haveEvent)
            {
                Game.Instance.RoomEventManager.StartRandomEvent();
                haveEvent = false;
            }
        }

        private void OnDestroy()
        {
            StopPlayerTracking();
        }

        private void StopPlayerTracking()
        {
            floorsNear[0].onCharacterEnter -= OnCharacterNearEnter;
            floorsNear[0].onCharacterLeave -= OnCharacterNearLeave;
            floorsNear[1].onCharacterEnter -= OnCharacterNearEnter;
            floorsNear[1].onCharacterLeave -= OnCharacterNearLeave;
        }
    }
}