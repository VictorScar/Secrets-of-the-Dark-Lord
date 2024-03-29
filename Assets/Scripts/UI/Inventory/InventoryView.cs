﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using System.Text;
using SODL.Core;
using SODL.Inventory;
using SODL.Utils;


namespace SODL.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] List<ItemCellPair> pairs = new List<ItemCellPair>();
        CharacterInventory PlayerInventory { get => Game.Instance.Player.Inventory; }
        int pastPairCount = 0;

        [Header("Info Panel")]
        [SerializeField] GameObject infoPanel;
        [SerializeField] TMPro.TMP_Text infoText;

        private void Awake()
        {
            InitInventory();
            PlayerInventory.OnInventoryUpdated += () =>
            {
                if (isActiveAndEnabled)
                {
                    ShowInventory();
                }
            };
        }

        private void InitInventory()
        {
            for (int i = 0; i < pairs.Count; i++)
            {
                ItemCellPair pair = pairs[i];
                pair.cell.onClick += OnCellClick;
                pair.cell.onPointerEnter += ShowItemInfoPanel;
                pair.cell.onPointerExit += HideItemInfoPanel;
                pair.slot = PlayerInventory.InventorySlots[i];
            }
        }

        void ShowInventory()
        {
            //Получение пар с не пустыми значениями предметов из инвенторя игрока
            ItemCellPair[] filledPairs = pairs.Where(pair => pair.slot.item != null).ToArray();

            //С целью оптимизации (не обрабатывать пустые неизменившиеся ячейки) определяем количество перерисовываемых объектов
            int redrawCellsCount = Mathf.Max(pastPairCount, filledPairs.Length);
            if (redrawCellsCount < 1)
            {
                redrawCellsCount = 1;
            }

            //В цикле берем каждую пару, которая содержит предметы или менялась с последней прорисовки
            //и вызываем функию ее перерисовки, с аргументами, возвращенными функцией обновления данных о прорисовке
            for (int i = 0; i < redrawCellsCount; i++)
            {
                ItemCellPair pair = pairs[i];
                pair.cell.Redraw(BuildDrawData(pair.slot));
            }

            //Сохранение количества заполненных пар
            pastPairCount = filledPairs.Length;
        }

        /// <summary>
        /// Функция создания набора данных о прорисовке ячейки инвентаря в зависимости от текущих состояний предмета
        /// </summary>
        public CellDrawData BuildDrawData(InventorySlot slot)
        {
            CellDrawData data = new CellDrawData();
            data.icon = slot.item?.Icon;
            data.iconColor = slot.item != null ? Color.white : Color.clear;
            data.countText = slot.count >= 1 ? slot.count.ToString() : string.Empty;
            data.highlightColor = slot.isWeared ? Color.red : Color.white;
            return data;
        }

        private void OnEnable()
        {
            ShowInventory();
        }

        private void OnCellClick(CellUI cell)
        {
            InventorySlot selectedItem = pairs.First(p => cell == p.cell).slot;

            if (selectedItem.item != null)
            {
                PlayerInventory.UseItem(selectedItem);
                //cell.Redraw(BuildDrawData(selectedItem));
            }
        }

        /// <summary>
        /// Функция, отображающая информационную панель с характерстиками предмета в инвентаре, на который наведен курсор
        /// </summary>
        /// <param name="cell"></param>
        public void ShowItemInfoPanel(CellUI cell)
        {
            InventorySlot pointerItem = pairs.First(p => cell == p.cell).slot;

            //Если в ячейке есть какой-то предмет
            if (pointerItem.item != null)
            {
                var cellRectTransform = cell.transform as RectTransform;
                var infoPanelRectTransform = infoPanel.transform as RectTransform;
                infoPanelRectTransform.anchoredPosition = cellRectTransform.anchoredPosition;
                infoText.text = DescriptionBuilder.GetItemDescription(pointerItem);
                infoPanel.SetActive(true);
            }
        }
        public void HideItemInfoPanel(CellUI cell)
        {
            infoPanel.SetActive(false);
        }

        private void Reset()
        {
            var cells = GetComponentsInChildren<CellUI>();
            foreach (CellUI cell in cells)
            {
                ItemCellPair pair = new ItemCellPair()
                {
                    cell = cell,
                    slot = null
                };
                pairs.Add(pair);
            }
        }
    }
}