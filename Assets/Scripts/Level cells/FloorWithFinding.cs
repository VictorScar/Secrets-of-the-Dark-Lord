using SODL.Character;
using SODL.Core;
using SODL.Finding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Cells
{
    public class FloorWithFinding : Floor
    {
        bool haveFinding = true;
        [SerializeField] Material emptyFindingMaterial;


        public override void OnCharacterMove(GameCharacter character)
        {
            base.OnCharacterMove(character);
            if (haveFinding)
            {
                Game game = Game.Instance;
                FindingInfo finding = game.FindingsGenerator.GenerateFinding();
                FindingCardEffect effect = game.EffectSystem.FindingCardEffect;
                if (finding != null)
                {
                    character.Inventory.AddItem(finding.Item, finding.ItemCount);
                    effect.Show(finding);
                }

                renderer.material = emptyFindingMaterial;
                haveFinding = false;
            }
        }
    }
}