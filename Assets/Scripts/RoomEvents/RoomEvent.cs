using UnityEngine;
using SODL.Core;

namespace SODL.RoomEvents
{
    [CreateAssetMenu(fileName = "RoomEvent", menuName = "ScriptableObjects/RoomEvent")]
    public class RoomEvent : ScriptableObject
    {
        [SerializeField] string description;
        [SerializeField] Answer[] answers;
        QuestionUI questionUI = null;

        QuestionUI QuestionUI
        {
            get
            {
                if (questionUI == null) questionUI = Game.Instance.QuestionUI;
                return questionUI;
            }
        }

        public virtual void Run()
        {
            QuestionUI.InitEventPanel(description, answers);
        }
    }
}