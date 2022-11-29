using SODL.Cells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.UI
{
    public class DoorUIPool : MonoBehaviour
    {
        [SerializeField] DoorUI doorUIPrefab;
        [SerializeField] int maxCapacity = 4;
        Stack<DoorUI> pool = new Stack<DoorUI>();

        private void Start()
        {
            for (int i = 0; i < maxCapacity; i++)
            {
                var doorUI = Instantiate(doorUIPrefab, transform);
                pool.Push(doorUI);
                doorUI.gameObject.SetActive(false);
            }
        }

        public DoorUI GetDoorUI()
        {
            if (pool.Count > 0)
            {
                DoorUI doorUI = pool.Pop();
                doorUI.gameObject.SetActive(true);
                return doorUI;
            }

            Debug.LogError("Стак дверей исчерпан!");
            return null;
        }

        public void ReturnDoorUI(DoorUI doorUI)
        {
            doorUI.gameObject.SetActive(false);
            pool.Push(doorUI);
        }
    }
}