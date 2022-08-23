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
        //��������� ������ Item, � ���� ������������ ��� �������� �� ������� ���������
        //�� ��������� ������, �� ����������� ������
        //����� �� ���������� � ����� ��� �� ������ ������ ��������� ������ � ����������� � ������ �����������
        //��������� ������ �������������� ���������

        //������� ����� ����������� �����
        for (int i = 0; i < filledCells; i++)
        {
            CellUI cell = cells[i];
            cell.CleanIcon();
        }

        //��������� �� ������ ��������� �� ��������� ������
        var items = PlayerInventory.Items.Where(i => i != null).ToArray();

        //���������� ����� �������� ���������
        for (int i = 0; i < items.Length; i++)
        {
            cells[i].SetIcon(items[i].Icon);
        }

        //���������� ���������� ����������� �����
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
