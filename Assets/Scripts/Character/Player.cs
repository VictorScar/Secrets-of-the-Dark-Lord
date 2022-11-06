using SODL.Cells;
using SODL.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class Player : GameCharacter
    {
        protected override void Awake()
        {
            base.Awake();
            Game.Instance.Player = this;
            Health = 3;
        }
    }
}