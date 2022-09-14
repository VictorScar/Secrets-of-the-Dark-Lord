using SODL.Finding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Core
{
    public class EffectSystem : MonoBehaviour
    {
        [SerializeField] FindingCardEffect findingCardEffect;

        public FindingCardEffect FindingCardEffect { get => findingCardEffect; }
    }
}