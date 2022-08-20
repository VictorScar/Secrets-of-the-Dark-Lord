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
    [SerializeField] bool isWearable;
    [SerializeField] float damage;
    [SerializeField] float defence;
    enum TypeofItem
    {
        onehandedWeapon,
        twohandedWeapon,
        helmet,
        armor,
        boots,
        gloves,
        shield,
    }


    public Sprite Icon { get => icon;}
    public bool IsWearable { get => isWearable;}
}
