using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class InventoryView : MonoBehaviour
{
    [SerializeField] CellUI[] cells;
    int filledCells = 0;

    Inventory PlayerInventory { get => Game.Instance.Player.Inventory; }
    private void Start()
    {
        foreach (CellUI cell in cells)
        {
            cell.onClick += OnCellClick;
        }
    }
    void ShowInventory()
    {
        //Создается массив Item, в него записываются все элементы из массива предметов
        //из инвенторя игрока, за исключением пустых
        //Далее мы перебираем в цикле все не пустые ячейки инвентаря игрока и присваиваем в ячейки визуального
        //инвентаря иконки соответствуюих предметов

        //Очистка ранее заполненных ячеек
        for (int i = 0; i < filledCells; i++)
        {
            CellUI cell = cells[i];
            cell.CleanIcon();
            cell.CleanCount();
            cell.CleanHighlight();
        }

        //Получение не пустых предметов из инвенторя игрока
        var itemsInfo = PlayerInventory.ItemsInfo.Where(i => i.item != null).ToArray();

        //Заполнение ячеек иконками предметов
        for (int i = 0; i < itemsInfo.Length; i++)
        {
            cells[i].SetIcon(itemsInfo[i].item.Icon);
            cells[i].SetCount(itemsInfo[i].count);
            if (PlayerInventory.IsWeared(itemsInfo[i].item))
            {
                cells[i].HighlightCell();
            }
        }

        //Сохранение количества заполненных ячеек
        filledCells = itemsInfo.Length;
    }

    private void OnEnable()
    {
        ShowInventory();
    }

    void OnCellClick(CellUI cell)
    {
        int index = Array.IndexOf(cells, cell);
        Item selectedItem = PlayerInventory.ItemsInfo[index].item;
        if (selectedItem != null)
        {
            bool isWeared = PlayerInventory.UseItem(selectedItem);
            if (isWeared)
            {
                cell.HighlightCell();
            }
        }
    }

    private void Reset()
    {
        cells = GetComponentsInChildren<CellUI>();
    }
}
