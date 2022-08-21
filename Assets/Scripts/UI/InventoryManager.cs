using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InventoryManager : MonoBehaviour
{
    // Dictionary<CellUI, ItemInfo> inventoryDict = new Dictionary<CellUI, ItemInfo>();
    //[SerializeField] CellUI[] cells;

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

        //for (int i = 0; i < PlayerInventory.ItemsInfo.Length; i++)
        //{
        //    //inventoryDict.Add(cells[i], PlayerInventory.ItemsInfo[i]);
        //    pairs.Add(new ItemCellPair()
        //    {
        //        cell = cells[i],
        //        info = PlayerInventory.ItemsInfo[i]
        //    }
        //    );
        //}

    }

    void ShowInventory()
    {
        //Создается массив Item, в него записываются все элементы из массива предметов
        //из инвенторя игрока, за исключением пустых
        //Далее мы перебираем в цикле все не пустые ячейки инвентаря игрока и присваиваем в ячейки визуального
        //инвентаря иконки соответствуюих предметов

        //Очистка ранее заполненных ячеек
        //for (int i = 0; i < filledCells; i++)
        //{
        //    CellUI cell = pairs[i].cell;
        //    cell.CleanIcon();
        //    cell.CleanCount();
        //    cell.CleanHighlight();
        //}

        //Получение не пустых предметов из инвенторя игрока
        //var itemsInfo = PlayerInventory.ItemsInfo.Where(i => i.item != null).ToArray();
        ItemCellPair[] filledPairs = pairs.Where(pair => pair.info.item != null).ToArray();

        //Заполнение ячеек иконками предметов
        //for (int i = 0; i < itemsInfo.Length; i++)
        //{
        //    ItemCellPair pair = pairs[i];
        //    pair.cell.SetIcon(pair.info.item.Icon);
        //    pair.cell.SetCount(pair.info.count);
        //    if (PlayerInventory.IsWeared(pair.info.item))
        //    {
        //        pair.cell.HighlightCell();
        //    }
        //}
        int redrawCellsCount = Mathf.Max(pastPairCount, filledPairs.Length);
        for (int i = 0; i < redrawCellsCount; i++)
        {
            ItemCellPair pair = pairs[i];
            pair.cell.Redraw(BuildDrawData(pair.info));
        }
        //Сохранение количества заполненных ячеек
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
            if (isWeared)
            {
                cell.HighlightCell();
            }

        }
    }

    //IEnumerable <ItemCellPair> GetFilledPairs()
    //{
        
    //}

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
