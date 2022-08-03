using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    protected Map map;
    public Coord coord;
  

    public virtual void Init(Map map)
    {
        this.map = map;
    }

    public static explicit operator Cell(GameObject v)
    {
        throw new NotImplementedException();
    }
    //public virtual void OnLevelGenerated()
    //{

    //}
}
