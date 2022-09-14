using SODL.Finding;
using SODL.Inventory;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SODL.Utills
{
    public static class DescriptionBuilder
    {
        /// <summary>
        /// Универсальный метод. Формирует информацию о предмете
        /// </summary>
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

        /// <summary>
        /// Формирует информацию о находке
        /// </summary>
        public static string GetItemDescription(FindingInfo finding)
        {
            return GetItemDescription(finding.Item, finding.ItemCount);
        }

        /// <summary>
        /// Формирует информацию о слоте
        /// </summary>
        public static string GetItemDescription(InventorySlot slot)
        {
            return GetItemDescription(slot.item, slot.count);
        }
    }
}