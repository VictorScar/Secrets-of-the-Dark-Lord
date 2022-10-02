using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using ActionTypeInfo = System.Collections.Generic.KeyValuePair<SODL.ActionPoints.CharacterActionType, SODL.ActionPoints.CharacterActionInfo>;

namespace SODL.ActionPoints
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActionConfig")]
    public class CharacterActionConfig : ScriptableObject
    {
        [SerializeField, Utills.OneLine] List<ActionPairInfo> actions = new List<ActionPairInfo>();

        public CharacterActionInfo GetInfo(CharacterActionType actionType)
        {
            CharacterActionInfo info = null;

            foreach (ActionPairInfo action in actions)
            {
                if (action.ActionType == actionType)
                {
                    info = action.ActionInfo;
                    break;
                }
            }
            return info;
        }

        //public CharacterActionInfo GetInfo(CharacterActionType actionType)
        //{
        //    foreach (ActionTypeInfo action in actions)
        //    {
        //        if (action.Key == actionType)
        //        {
        //            return action.Value;
        //        }
        //    }
        //    return null;
        //}

        //public CharacterActionInfo GetInfo(CharacterActionType actionType)
        //{
        //    return actions.First<ActionTypeInfo>(pair => {
        //        var p = ()pair;
        //        return pair.Key == actionType;
        //    });
        //}
    }

    [System.Serializable]
    public class ActionPairInfo
    {
        [SerializeField] CharacterActionType actionType;
        [SerializeField] CharacterActionInfo actionInfo;

        public CharacterActionType ActionType { get => actionType; }
        public CharacterActionInfo ActionInfo { get => actionInfo; }
    }
}