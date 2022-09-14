using SODL.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.UI.Inventory
{
    [System.Serializable]
    public class ItemCellPair
    {
        public CellUI cell;
        public InventorySlot slot;
    }
}