using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class InventoryView : MonoBehaviour
{
    [SerializeField] CellUI[] cells;
    int filledCells = 0;
    Inventory PlayerInventory { get => Game.Instance.Player.Inventory; }

    void ShowInventory()
    {
        //—оздаетс€ массив Item, в него записываютс€ все элементы из массива предметов
        //из инвентор€ игрока, за исключением пустых
        //ƒалее мы перебираем в цикле все не пустые €чейки инвентар€ игрока и присваиваем в €чейки визуального
        //инвентар€ иконки соответствуюих предметов

        //ќчистка ранее заполненных €чеек
        for (int i = 0; i < filledCells; i++)
        {
            CellUI cell = cells[i];
            cell.CleanIcon();
        }

        //ѕолучение не пустых предметов из инвентор€ игрока
        var items = PlayerInventory.Items.Where(i => i != null).ToArray();

        //«аполнение €чеек иконками предметов
        for (int i = 0; i < items.Length; i++)
        {
            cells[i].SetIcon(items[i].Icon);
        }

        //—охранение количества заполненных €чеек
        filledCells = items.Length;
    }

    private void OnEnable()
    {
        ShowInventory();
    }

    private void Reset()
    {
        cells = GetComponentsInChildren<CellUI>();
    }
}
