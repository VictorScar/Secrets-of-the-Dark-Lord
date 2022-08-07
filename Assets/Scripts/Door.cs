using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Cell
{
    bool opened = false;
    public bool Opened { get { return opened; } }
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
        doorAnimator.Play("Open");

    }
    public void CloseDoor()
    {
        opened = false;
        doorAnimator.Play("Closed");

    }
}
