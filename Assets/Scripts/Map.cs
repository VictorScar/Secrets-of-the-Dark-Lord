using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Cell[,] cells;
    public int Width { get => cells.GetLength(0); }
    public int Height { get => cells.GetLength(1); }

  
    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            return cells[x, y];
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
