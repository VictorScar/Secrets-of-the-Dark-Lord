using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Finding
{
    [SerializeField] Item item;
    [SerializeField] int itemCount = 1;

    public Item Item { get => item; }
    public int ItemCount { get => itemCount;}
}
