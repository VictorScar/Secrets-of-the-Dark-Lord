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
        [SerializeField] TMP_Text gameMessageText;
        [SerializeField] Button turnOverButton;
        CharacterActionManager actionManager;

        private void Awake()
        {
            actionManager = Game.Instance.ActionManager;
            actionManager.onActionPointsChanged += UpdateActionPointsCount;
            actionManager.onCharacterFinished += ShowGameMessage;
            turnOverButton.onClick.AddListener(OnTurnOverButtonClicked);
        }

        private void ShowGameMessage()
        {
            StartCoroutine(ShowGameMessageCoroutine());
        }

        public void UpdateActionPointsCount()
        {
            actionPointsText.text = $"Очки действий: {actionManager.ActionPointCount}";
        }

        private void OnTurnOverButtonClicked()
        {
            actionManager.FinishTurn();
        }

        private IEnumerator ShowGameMessageCoroutine()
        {
            gameMessageText.enabled = true;
            yield return new WaitForSeconds(2);
            gameMessageText.enabled = false;
        }
    }
}