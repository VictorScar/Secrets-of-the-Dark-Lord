using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Cell
{
    public bool opened = false;
    Animator doorAnimation;


    public override void Init(Map map)
    {
        base.Init(map);
        OrientDoor();
        doorAnimation = GetComponentInChildren<Animator>();
       
    }

    private void OrientDoor()
    {
        if (GetBottomCell(this) is Floor)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
              
    }

    public void OpenDoor()
    {
        opened = true;
        doorAnimation.Play("Open");

    }
    public void CloseDoor()
    {
        opened = false;
        doorAnimation.Play("Closed");

    }
}
