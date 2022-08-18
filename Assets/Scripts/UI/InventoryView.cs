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
        //Создается массив Item, в него записываются все элементы из массива предметов
        //из инвенторя игрока, за исключением пустых
        //Далее мы перебираем в цикле все не пустые ячейки инвентаря игрока и присваиваем в ячейки визуального
        //инвентаря иконки соответствуюих предметов

        //Очистка ранее заполненных ячеек
        for (int i = 0; i < filledCells; i++)
        {
            CellUI cell = cells[i];
            cell.CleanIcon();
        }

        //Получение не пустых предметов из инвенторя игрока
        var items = PlayerInventory.Items.Where(i => i != null).ToArray();

        //Заполнение ячеек иконками предметов
        for (int i = 0; i < items.Length; i++)
        {
            cells[i].SetIcon(items[i].Icon);
        }

        //Сохранение количества заполненных ячеек
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
