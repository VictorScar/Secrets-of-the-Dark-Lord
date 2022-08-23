using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> usedItems = new List<Item>();
    [SerializeField, OneLine] ItemInfo[] itemsInfo = new ItemInfo[30];
    [SerializeField] Item item;

    public ItemInfo[] ItemsInfo { get => itemsInfo; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem(item);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveItem(item);
        }
    }

    public void UseItem(ItemInfo info)
    {
        if (info.item.IsWearable)
        {
            if (info.isWeared)
            {
                usedItems.Remove(info.item);
                info.isWeared = false;
            }
            else
            {
                usedItems.Add(info.item);
                info.isWeared = true;
            }
        }
    }

    public bool IsWeared(Item item)
    {
        return usedItems.Contains(item);
    }

    public void AddItem(Item item)
    {
        foreach (ItemInfo info in itemsInfo)
        {
            if (info.item == item)
            {
                info.count++;
                break;
            }
            else if (info.item == null)
            {
                info.item = item;
                info.count = 1;
                break;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        foreach (ItemInfo info in itemsInfo)
        {
            if (info.item == item)
            {
                info.count--;
                if (info.count < 1)
                {
                    info.item = null;
                    info.isWeared = false;
                    usedItems.Remove(item);
                }
                break;
            }
        }
    }
}
