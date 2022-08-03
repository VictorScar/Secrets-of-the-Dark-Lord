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
        if (map.GetBottomCell(gameObject.GetComponent<Door>()) is Floor)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
       
            //if (id == 2 && levelData[x, y - 1] != null && levelData[x, y - 1] == "1")
        //{
        //    angle = 90f;
        //}
        //else angle = 0;

    }

    public void OpenDoor()
    {
        opened = true;

    }
}
