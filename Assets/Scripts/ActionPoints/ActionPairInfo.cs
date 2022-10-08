using UnityEngine;

namespace SODL.ActionPoints
{
    [System.Serializable]
    public class ActionPairInfo
    {
        [SerializeField] CharacterActionType actionType;
        [SerializeField] CharacterActionInfo actionInfo;

        public CharacterActionType ActionType { get => actionType; }
        public CharacterActionInfo ActionInfo { get => actionInfo; }
    }
}