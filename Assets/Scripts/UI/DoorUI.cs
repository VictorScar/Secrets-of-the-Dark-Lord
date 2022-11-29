using SODL.ActionPoints;
using SODL.Cells;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUI : MonoBehaviour
{
    CharacterActionManager actionManager;
    new Camera camera;
    //public Door Door { get; set; } = null;
    Door door;
    [SerializeField] Button uiButton;

    [SerializeField] Vector2 offset;

    CharacterActionType actionType;

    private void Start()
    {
        camera = Game.Instance.PlayerCamera.Camera;
        uiButton.onClick.AddListener(OpenDoor);
    }

    public void Init(Door door, CharacterActionType openDoorActionType)
    {
        if (actionManager == null)
        {
            actionManager = Game.Instance.ActionManager;
        }
        this.door = door;
        actionType = openDoorActionType;
        CanOpenDoor();
        actionManager.onActionPointsChanged += CanOpenDoor;
    }

    public void Finish()
    {
        door = null;
        actionType = CharacterActionType.None;
        actionManager.onActionPointsChanged -= CanOpenDoor;
    }

    private void LateUpdate()
    {
        if (door != null)
        {
            transform.position = camera.WorldToScreenPoint(door.transform.position) + (Vector3)offset;
        }
    }

    void CanOpenDoor()
    {
        uiButton.interactable = actionManager.CanDoAction(actionType);
    }

    private void OpenDoor()
    {
        if (actionManager.DoAction(CharacterActionType.OpenDoor))
        {
            door.OpenDoor();
        }
    }

    private void OnDestroy()
    {
        uiButton.onClick.RemoveListener(OpenDoor);
    }
}
