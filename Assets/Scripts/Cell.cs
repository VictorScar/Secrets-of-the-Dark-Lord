using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Cell : MonoBehaviour
{
    protected Map map;
    public Coord coord;
    Cell cell;
    public Map Map { get { return map; } }

    public virtual void Init(Map map)
    {
        this.map = map;
        cell = gameObject.GetComponent<Cell>();
    }

   

    public Cell GetBottomCell()
    {
        return map.GetBottomCell(cell);
    }

    public Cell GetUpperCell()
    {
     
        return map.GetUpperCell(cell);
    }

    public Cell GetLeftCell()
    {
        
        return map.GetLeftCell(cell);
    }

    public Cell GetRightCell()
    {
       
        return map.GetRightCell(cell);
    }

}
