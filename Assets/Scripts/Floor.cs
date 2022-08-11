using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Cell
{
    [SerializeField] new Renderer renderer;
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
