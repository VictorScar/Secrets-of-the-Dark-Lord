using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Cell : MonoBehaviour
{
    protected Map map;
    public Coord coord;

    public Map Map { get { return map; } }

    public virtual void Init(Map map)
    {
        this.map = map;
    }



    public Cell GetBottomCell()
    {
        return map.GetBottomCell(this);
    }

    public Cell GetUpperCell()
    {

        return map.GetUpperCell(this);
    }

    public Cell GetLeftCell()
    {

        return map.GetLeftCell(this);
    }

    public Cell GetRightCell()
    {

        return map.GetRightCell(this);
    }

}
