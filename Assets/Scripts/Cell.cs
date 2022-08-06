using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Cell : MonoBehaviour
{
    protected Map map;
    public Coord coord;
   


    public virtual void Init(Map map)
    {
        this.map = map;
       //coord = new Coord((int)transform.position.x, (int)transform.position.z);
    }

    public Cell GetCell(int x, int y)
    {
        return map.GetCell(x, y);
    }

    public Cell GetBottomCell(Cell cell)
    {
        return map.GetBottomCell(cell);
    }

    public Cell GetUpperCell(Cell cell)
    {
     
        return map.GetUpperCell(cell);
    }

    public Cell GetLeftCell(Cell cell)
    {
        
        return map.GetLeftCell(cell);
    }

    public Cell GetRightCell(Cell cell)
    {
       
        return map.GetRightCell(cell);
    }

}
