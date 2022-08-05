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
    }

    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < map.Width && y >= 0 && y < map.Height)
        {
            return map.cells[x, y];
        }
        else
        {
            return null;
        }
    }

    public Cell GetBottomCell(Cell cell)
    {
        int x = cell.coord.x;
        int y = cell.coord.y;
        return GetCell(x, y - 1);
    }

    public Cell GetUpperCell(Cell cell)
    {
        int x = cell.coord.x;
        int y = cell.coord.y;
        return GetCell(x, y + 1);
    }

    public Cell GetLeftCell(Cell cell)
    {
        int x = cell.coord.x;
        int y = cell.coord.y;
        return GetCell(x - 1, y);
    }

    public Cell GetRightCell(Cell cell)
    {
        int x = cell.coord.x;
        int y = cell.coord.y;
        return GetCell(x + 1, y);
    }

}
