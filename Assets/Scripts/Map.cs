using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Cell[,] cells;
    public int Width { get => cells.GetLength(0); }
    public int Height { get => cells.GetLength(1); }

    public Cell GetBottomCell(Cell cell)
    {
        int x = cell.coord.x;
        int y = cell.coord.y;
        Cell bottomCell = null;
        if (y > 0 && y <= Height)
        {
            bottomCell = cells[x, y-1];
        }

        return bottomCell;
    }


}
