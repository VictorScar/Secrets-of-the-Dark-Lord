using SODL.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class FriendlyCharacter : GameCharacter
    {
        Player owner;

        public override void AddItem(Item item, int count)
        {
            owner.AddItem(item, count);
        }
    }
}