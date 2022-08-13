using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField] Item[] items = new Item[20];
    public Item [] Items { get => items;}

    public void Use(Item item)
    {

    }
}
