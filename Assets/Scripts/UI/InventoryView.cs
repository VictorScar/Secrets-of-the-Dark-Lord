using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class InventoryView : MonoBehaviour
{
    [SerializeField] CellUI[] cells;
    Inventory PlayerInventory { get => Game.Instance.Player.Inventory; }

    void ShowInventory()
    {
        var items = PlayerInventory.Items.Where(i => i != null).ToArray();
        for (int i = 0; i < items.Length; i++)
        {
            cells[i].SetIcon(items[i].Icon);
        }
    }

    private void Start()
    {
        Invoke("ShowInventory", 1f);
    }

    private void Reset()
    {
        cells = GetComponentsInChildren<CellUI>();
    }
}
