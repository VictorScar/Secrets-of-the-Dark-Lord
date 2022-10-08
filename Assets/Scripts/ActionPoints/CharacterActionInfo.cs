using SODL.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.ActionPoints
{
    [System.Serializable]
    public class CharacterActionInfo
    {
        [SerializeField] int requiredPoints = 0;
        [SerializeField] Item requiredItem;

        public int RequiredPoints { get => requiredPoints; private set => requiredPoints = value; }
        public Item RequiredItem { get => requiredItem; private set => requiredItem = value; }
    }
}