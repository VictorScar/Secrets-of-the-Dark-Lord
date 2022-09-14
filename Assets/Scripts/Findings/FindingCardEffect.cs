using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using SODL.Core;
using SODL.Utills;

namespace SODL.Finding
{
    public class FindingCardEffect : MonoBehaviour
    {
        [Header("Компоненты")]
        [SerializeField] SpriteRenderer iconSpriteRenderer;
        [SerializeField] TMP_Text descriptionText;
        [SerializeField] Camera playerCamera;

        [Header("Анимация")]
        [SerializeField] float showDuration = 2f;

        public void Show(FindingInfo finding)
        {
            descriptionText.text = DescriptionBuilder.GetItemDescription(finding);
            iconSpriteRenderer.sprite = finding.Item.Icon;
            gameObject.SetActive(true);
            StartCoroutine(ShowAnimation());
        }

        IEnumerator ShowAnimation()
        {
            Transform findingEffectPosition = Game.Instance.PlayerCamera.FindingEffectPosition;
            transform.position = findingEffectPosition.position;
            transform.rotation = findingEffectPosition.rotation;
            yield return new WaitForSeconds(showDuration);
            gameObject.SetActive(false);
        }
    }
}