using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] public string itemName;
    [SerializeField] int price;
    public int count;

    public Sprite Icon { get => icon;}
}
