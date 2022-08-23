using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] public string itemName;

    [Header("Параметры использования")]
    [SerializeField] WearSlot wearSlot;

    [Header("Характеристики")]
    [SerializeField] float damage;
    [SerializeField] float defence;
    [SerializeField] int price;
    public Sprite Icon { get => icon; }
    public bool IsWearable { get => wearSlot != WearSlot.None; }
}
