using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Cell
{
    public bool Opened { get; protected set; }

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
    }
    public void CloseDoor()
    {
        Opened = false;
        doorAnimator.Play("Closed");
    }

    public override bool OnBeforePlayerMove(Player player)
    {
        if (!Opened)
        {
            OpenDoor();
            return false;
        }
        return true;
    }
}
