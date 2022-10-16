using UnityEngine;

namespace SODL.RoomEvents
{
    [System.Serializable]
    public class Answer
    {
        [SerializeField] string answerText;
        [SerializeField] string resultText;
        [SerializeReference, SubclassSelector] IGameAction gameAction;

        public string AnswerText { get => answerText; }
        public string ResultText { get => resultText; }
        public IGameAction GameAction { get => gameAction; }
    }
}