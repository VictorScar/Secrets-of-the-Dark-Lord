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

   
}
