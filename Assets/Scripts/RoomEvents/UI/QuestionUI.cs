using UnityEngine;
using TMPro;
using SODL.UI;

namespace SODL.RoomEvents
{
    public class QuestionUI : MonoBehaviour
    {
        [Header("Event panel")]

        [SerializeField] GameObject roomEventPanel;
        [SerializeField] TMP_Text questionText;
        [SerializeField] AnswerButton[] answerButtons;


        [Header("Answer panel")]

        [SerializeField] InfoPanel answerPanel;

        private void Awake()
        {
            DisableButtons();
        }

        public void InitEventPanel(string question, Answer[] answers)
        {
            questionText.text = question;
            roomEventPanel.SetActive(true);

            for (int i = 0; i < answers.Length; i++)
            {
                AnswerButton currentButton = answerButtons[i];
                Answer currentAnswer = answers[i];

                currentButton.Text = currentAnswer.AnswerText;
                currentButton.gameObject.SetActive(true);

                currentButton.onClickAnswer += () =>
                {
                    currentAnswer.GameAction?.Run();
                    ShowAnswerPanel(currentAnswer);
                };
            }
        }

        public void ShowAnswerPanel(Answer answer)
        {
            //Отписывает действия ответов от события нажатия кнопки
            foreach (var button in answerButtons)
            {
                button.RemoveAllListeners();
            }

            roomEventPanel.SetActive(false);
            DisableButtons();
            answerPanel.ShowInfoPanel(answer.ResultText);
        }

        private void DisableButtons()
        {
            foreach (AnswerButton button in answerButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}