using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleButton : MonoBehaviour
{
    [SerializeField] GameObject toggleObject;
    [SerializeField] Button button;


    private void Awake()
    {
        button.onClick.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        toggleObject.SetActive(!toggleObject.activeSelf);
    }
}
