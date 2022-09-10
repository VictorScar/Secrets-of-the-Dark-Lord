using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class DescriptionBuilder
{
    public static string GetItemDescription(Item item, int itemCount)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Название: {item.ItemName}");
        stringBuilder.AppendLine($"Количество: {itemCount}");
        stringBuilder.AppendLine($"Атака: {item.Attack}");
        stringBuilder.AppendLine($"Защита: {item.Defence}");
        stringBuilder.AppendLine($"Стоимость: {item.Price}");

        return stringBuilder.ToString();
    }

    public static string GetItemDescription(Finding finding)
    {
        return GetItemDescription(finding.Item, finding.ItemCount);
    }

    public static string GetItemDescription(InventorySlot slot)
    {
        return GetItemDescription(slot.item, slot.count);
    }
}
