using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

namespace SODL.UI.Inventory
{
    public class CellUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Image itemImage;
        [SerializeField] Image frameImage;
        [SerializeField] Image backgroundImage;
        [SerializeField] TMP_Text itemCount;
        [SerializeField] Color backgroundColorHovered;
        Color backgroundColor;

        public event Action<CellUI> onClick;
        public event Action<CellUI> onPointerEnter;
        public event Action<CellUI> onPointerExit;

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
            onPointerEnter?.Invoke(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            backgroundImage.color = backgroundColor;
            onPointerExit?.Invoke(this);
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
}