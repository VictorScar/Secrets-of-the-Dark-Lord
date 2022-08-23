using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class CellUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image itemImage;
    [SerializeField] Image frameImage;
    [SerializeField] Image backgroundImage;
    [SerializeField] TMP_Text itemCount;
    Color backgroundColor;
    [SerializeField] Color backgroundColorHovered;

    public event Action<CellUI> onClick;

    private void Start()
    {
        backgroundColor = backgroundImage.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundImage.color = backgroundColorHovered;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundImage.color = backgroundColor;
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
