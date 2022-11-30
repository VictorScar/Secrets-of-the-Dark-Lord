using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SODL.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]

    public class Item : ScriptableObject
    {
        [SerializeField] Sprite icon;
        [SerializeField] private string itemName;

        [Header("Параметры использования")]
        [SerializeField] WearSlot wearSlot;

        [Header("Характеристики")]
        [SerializeField] private float attack;
        [SerializeField] private float defence;
        [SerializeField] private int price;
        public Sprite Icon { get => icon; }
        public bool IsWearable { get => WearSlot != WearSlot.None; }
        public WearSlot WearSlot { get => wearSlot; }
        public string ItemName { get => itemName; }
        public float Attack { get => attack; }
        public float Defence { get => defence; }
        public int Price { get => price; }
    }
}