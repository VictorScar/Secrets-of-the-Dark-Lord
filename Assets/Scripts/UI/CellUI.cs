using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class CellUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemImage;
    [SerializeField] Image frameImage;
    [SerializeField] TMP_Text itemCount;

    public event Action<CellUI> onClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(this);
    }
    public void HighlightCell()
    {
        frameImage.color = Color.red;
    }

    public void CleanHighlight()
    {
        frameImage.color = Color.white;
    }

    public void Redraw(CellDrawData data)
    {
        itemImage.sprite = data.icon;
        itemImage.color = data.iconColor;
        itemCount.text = data.countText;
        frameImage.color = data.highlightColor;
    }
}
