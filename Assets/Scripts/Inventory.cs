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
    public void RaiseItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            //if (item == items[i])
            //{
            //    items[i].count++;
            //}
            if (items[i] == null)
            {
                items[i] = item;
                break;
            }
        }
    }
}
