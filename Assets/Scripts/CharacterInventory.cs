using SODL.ActionPoints;
using SODL.Inventory;
using SODL.Utills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SODL.Core
{
    public class CharacterInventory : MonoBehaviour
    {
        [SerializeField] List<InventorySlot> usedSlots = new List<InventorySlot>();
        [SerializeField, OneLine] InventorySlot[] inventorySlots = new InventorySlot[30];
        [SerializeField] Item item;
        CharacterActionManager actionManager;
        public event Action OnInventoryUpdated;

        public InventorySlot[] InventorySlots { get => inventorySlots; }

        private void Start()
        {
            actionManager = Game.Instance.ActionManager;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddItem(item, 1);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RemoveItem(item);
            }
        }

        public void UseItem(InventorySlot inventorySlot)
        {
            //Проверка надеваемый ли предмет
            if (inventorySlot.item.IsWearable && actionManager.DoAction(CharacterActionType.WearItem))
            {
                //Проходим по списку используемых предметов и получаем все предметы такого же или соответствующих типов
                //и снимаем их
                var wearedSlots = GetWearedMatchingSlots(inventorySlot.item.WearSlot).ToArray();

                foreach (InventorySlot wearedSlot in wearedSlots)
                {
                    usedSlots.Remove(wearedSlot);
                    wearedSlot.isWeared = false;
                }

                //Надеваем текущий предмет
                if (!wearedSlots.Contains(inventorySlot))
                {
                    usedSlots.Add(inventorySlot);
                    inventorySlot.isWeared = true;
                }

                OnInventoryUpdated?.Invoke();
            }
        }

        public bool HasItem(Item item)
        {
            return InventorySlots.Any(x => x.item == item);
        }

        /// <summary>
        /// Функция, возвращающая коллекцию предметов, препятствующих надеванию предмета с типом WearSlot (из параметров)
        /// Если получен предмет типа "Двуручное оружие", то вернутся предметы с типами "Двуручное" и для "левой и правой руки"
        /// </summary>
        IEnumerable<InventorySlot> GetWearedMatchingSlots(WearSlot wearSlot)
        {
            foreach (InventorySlot inventorySlot in usedSlots)
            {
                //Проверяем наличие предмета с типом, указанным в параметрах метода
                if (inventorySlot.item.WearSlot == wearSlot)
                {
                    yield return inventorySlot;
                }
                //Проверяем указанный тип на соответствие типу "Двуручное оружие". Если соответствие есть, то проверяем
                //наличие предметов с типами для левой и правой руки
                else if (wearSlot == WearSlot.BothHands)
                {
                    if (inventorySlot.item.WearSlot == WearSlot.LeftHand || inventorySlot.item.WearSlot == WearSlot.RightHand)
                    {
                        yield return inventorySlot;
                    }
                }
                //Проверяем указанный тип на соответствие типам "Левая" или "Правая рука". Если соответствие есть, то проверяем
                //наличие предмета с типом "Двуручное оружие"
                else if (wearSlot == WearSlot.LeftHand || wearSlot == WearSlot.RightHand)
                {
                    if (inventorySlot.item.WearSlot == WearSlot.BothHands)
                    {
                        yield return inventorySlot;
                    }
                }
            }
        }

        public void AddItem(Item item, int count)
        {
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.item == item)
                {
                    inventorySlot.count += count;
                    break;
                }
                else if (inventorySlot.item == null)
                {
                    inventorySlot.item = item;
                    inventorySlot.count = count;
                    break;
                }
            }
            OnInventoryUpdated?.Invoke();
        }

        public void RemoveItem(Item item)
        {
            foreach (InventorySlot inventorySlot in inventorySlots)
            {
                if (inventorySlot.item == item)
                {
                    inventorySlot.count--;
                    if (inventorySlot.count < 1)
                    {
                        inventorySlot.item = null;
                        inventorySlot.isWeared = false;
                        usedSlots.Remove(inventorySlot);
                    }
                    break;
                }
            }
            OnInventoryUpdated?.Invoke();
        }
    }
}