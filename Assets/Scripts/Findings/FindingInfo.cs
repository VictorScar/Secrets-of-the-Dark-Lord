using SODL.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Finding
{
    [System.Serializable]
    public class FindingInfo
    {
        [SerializeField] Item item;
        [SerializeField] int itemCount = 1;

        public Item Item { get => item; }
        public int ItemCount { get => itemCount; }
    }
}