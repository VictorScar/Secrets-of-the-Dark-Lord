using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUIManager : MonoBehaviour
{
    [SerializeField] GameObject doorUIPrefab;
    [SerializeField] int countDoorUI;
    List <GameObject> pool;

    private void Start()
    {
        pool = new List <GameObject>();

        for (int i = 0; i < countDoorUI; i++)
        {
            var doorUI = Instantiate(doorUIPrefab, transform);
            pool.Add(doorUI);
            doorUI.SetActive(false);
        }
    }

    void GiveDoorUI()
    {

    }
}
