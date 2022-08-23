using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class InventoryView : MonoBehaviour
{
    [SerializeField] List<ItemCellPair> pairs = new List<ItemCellPair>();
    Inventory PlayerInventory { get => Game.Instance.Player.Inventory; }
    int pastPairCount = 0;

    private void Start()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < pairs.Count; i++)
        {
            ItemCellPair pair = pairs[i];
            pair.cell.onClick += OnCellClick;
            pair.info = PlayerInventory.ItemsInfo[i];
        }
    }

    void ShowInventory()
    {
        //Получение пар с не пустыми значениями предметов из инвенторя игрока
        ItemCellPair[] filledPairs = pairs.Where(pair => pair.info.item != null).ToArray();

        //С целью оптимизации (не обьрабатывать пустые неизменившиеся ячейки) определяем количество перерисовываемых объектов
        int redrawCellsCount = Mathf.Max(pastPairCount, filledPairs.Length);

        //В цикле берем каждую пару, которая содержит предметы или менялась с последней прорисовки
        //и вызываем функию ее перерисовки, с аргументами, возвращенными функцией обновления данных о прорисовке
        for (int i = 0; i < redrawCellsCount; i++)
        {
            ItemCellPair pair = pairs[i];
            pair.cell.Redraw(BuildDrawData(pair.info));
        }

        //Сохранение количества заполненных пар
        pastPairCount = filledPairs.Length;
    }

    /// <summary>
    /// Функция создания набора данных о прорисовке ячейки инвентаря в зависимости от текущих состояний предмета
    /// </summary>
    public CellDrawData BuildDrawData(ItemInfo info)
    {
        CellDrawData data = new CellDrawData();
        data.icon = info.item?.Icon;
        data.iconColor = info.item != null ? Color.white : Color.clear;
        data.countText = info.count >= 1 ? info.count.ToString() : string.Empty;
        data.highlightColor = info.isWeared ? Color.red : Color.white;
        return data;
    }

    private void OnEnable()
    {
        ShowInventory();
    }

    private void OnCellClick(CellUI cell)
    {
        ItemInfo selectedItem = pairs.First(p => cell == p.cell).info;

        if (selectedItem.item != null)
        {
            PlayerInventory.UseItem(selectedItem);
            cell.Redraw(BuildDrawData(selectedItem));
        }
    }

    private void Reset()
    {
        var cells = GetComponentsInChildren<CellUI>();
        foreach (CellUI cell in cells)
        {
            ItemCellPair pair = new ItemCellPair()
            {
                cell = cell,
                info = null
            };
            pairs.Add(pair);
        }
    }
}
