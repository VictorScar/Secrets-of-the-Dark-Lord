using UnityEngine;
using SODL.Core;
using SODL.Utils;

namespace SODL.RoomEvents
{
    [CreateAssetMenu(fileName = "RoomEvent", menuName = "ScriptableObjects/RoomEvent")]
    public class RoomEvent : ScriptableObject
    {
        [SerializeField] string description;
        [SerializeField] Answer[] answers;
        Cached<QuestionUI> questionUICached = new Cached<QuestionUI>(() => Game.Instance.QuestionUI);

        public virtual void Run()
        {
            questionUICached.Value.InitEventPanel(description, answers);
        }
    }
}