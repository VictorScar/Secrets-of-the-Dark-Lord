using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    Dictionary<CellUI, ItemInfo> inventoryList;
    [SerializeField] CellUI[] cells;
    Inventory PlayerInventory { get => Game.Instance.Player.Inventory; }

    private void Start()
    {
        foreach (CellUI cell in cells)
        {
            cell.onClick += OnCellClick;
        }
    }

    private Dictionary<CellUI, ItemInfo> InitInventory()
    {
        for (int i = 0; i < PlayerInventory.ItemsInfo.Length; i++)
        {
            inventoryList = new Dictionary<CellUI, ItemInfo>();
            inventoryList.Add(cells[i], PlayerInventory.ItemsInfo[i]);
        }
        return inventoryList;
    }

    void Redraw(CellDrawData data)
    {
      foreach(var stack in inventoryList)
        {
            stack.Key.SetIcon(stack.Value.item.Icon);
        }
    }

    private void OnCellClick(CellUI cell)
    {
        inventoryList.TryGetValue(cell, out ItemInfo selectedItem);

        if (selectedItem != null)
        {
            bool isWeared = PlayerInventory.UseItem(selectedItem.item);
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
