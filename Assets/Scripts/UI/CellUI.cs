using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        //itemImage.color = Color.red;
    }

    public void SetIcon(Sprite icon)
    {
        itemImage.sprite = icon;
        itemImage.color = Color.white;
    }
}
