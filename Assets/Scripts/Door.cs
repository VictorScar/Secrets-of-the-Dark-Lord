using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Cell
{
    bool opened = false; 


    public override void Init(Map map)
    {
        base.Init(map);
        OrientDoor();
    }

    private void OrientDoor()
    {
        if (map.GetBottomCell(this) is Floor)
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

    }
}
