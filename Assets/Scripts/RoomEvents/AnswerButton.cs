using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SODL.RoomEvents
{
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] TMP_Text buttonText;

        public string Text { get => buttonText.text; set => buttonText.text = value; }

        public event Action onClickAnswer;

        private void Start()
        {
            button.onClick.AddListener(OnClickAnswer);
        }

        void OnClickAnswer()
        {
            onClickAnswer?.Invoke();
        }

        public void RemoveAllListeners()
        {
            onClickAnswer = null;
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClickAnswer);
        }

        private void Reset()
        {
            button = GetComponent<Button>();
            buttonText = GetComponentInChildren<TMP_Text>();
        }
    }
}