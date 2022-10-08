using System.Collections.Generic;
using UnityEngine;

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
        //    return actions.First<ActionTypeInfo>(pair => {
        //        var p = ()pair;
        //        return pair.Key == actionType;
        //    });
        //}
    }
}