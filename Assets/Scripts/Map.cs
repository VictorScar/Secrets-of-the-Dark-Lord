using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Cell[,] cells;
    public int Width { get => cells.GetLength(0); }
    public int Height { get => cells.GetLength(1); }

  
   
}
