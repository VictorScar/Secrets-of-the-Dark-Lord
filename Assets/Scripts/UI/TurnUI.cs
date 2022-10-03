using SODL.ActionPoints;
using SODL.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SODL.UI.TurnParameters
{
    public class TurnUI : MonoBehaviour
    {
        [SerializeField] TMP_Text actionPointsText;
        [SerializeField] GameObject gameMessangeText;
        CharacterActionManager actionManager;

        private void Awake()
        {
            actionManager = Game.Instance.ActionManager;
            actionManager.onActionPointsChanged += ShowActionCount;
            actionManager.onCharacterFinished += ShowGameMessange;
        }

        private void ShowGameMessange()
        {
            StartCoroutine(ShowGameMessangeCoroutine());
        }

        public void ShowActionCount()
        {
            int actionPointCount = actionManager.ActionPointCount;
            StringBuilder actionPointBuilder = new StringBuilder("Очки действия: ");
            actionPointBuilder.Append(actionPointCount);
            actionPointsText.text = actionPointBuilder.ToString();
        }

        IEnumerator ShowGameMessangeCoroutine()
        {
            gameMessangeText.SetActive(true);
            yield return new WaitForSeconds(2);
            gameMessangeText.SetActive(false);
        }
    }
}