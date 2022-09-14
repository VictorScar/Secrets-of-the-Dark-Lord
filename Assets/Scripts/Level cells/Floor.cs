using SODL.Character;
using SODL.Utills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Cells
{
    public class Floor : Cell
    {
        [SerializeField] protected new Renderer renderer;
        [OneLine]
        [SerializeField] ObjectWithChance<Material>[] materials;
        void Start()
        {

            if (renderer != null && materials != null && materials.Length > 0)
            {
                renderer.material = Randomizer.RandomWithChance(materials);
            }
        }

        public override bool OnBeforePlayerMove(Player player)
        {
            return true;
        }

    }
}