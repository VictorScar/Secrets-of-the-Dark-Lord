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
        //Создается массив Item, в него записываются все элементы из массива предметов
        //из инвенторя игрока, за исключением пустых
        //Далее мы перебираем в цикле все не пустые ячейки инвентаря игрока и присваиваем в ячейки визуального
        //инвентаря иконки соответствуюих предметов


        //Получение пар с не пустыми значениями предметов из инвенторя игрока
        ItemCellPair[] filledPairs = pairs.Where(pair => pair.info.item != null).ToArray();

        //Заполнение ячеек иконками предметов

        int redrawCellsCount = Mathf.Max(pastPairCount, filledPairs.Length);
        for (int i = 0; i < redrawCellsCount; i++)
        {
            ItemCellPair pair = pairs[i];
            pair.cell.Redraw(BuildDrawData(pair.info));
        }
        //Сохранение количества заполненных пар
        pastPairCount = filledPairs.Length;
    }

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
            bool isWeared = PlayerInventory.UseItem(selectedItem);
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
