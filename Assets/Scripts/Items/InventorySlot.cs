using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Inventory
{
    [System.Serializable]
    public class InventorySlot
    {
        public Item item;
        public int count;
        public bool isWeared;
    }
}