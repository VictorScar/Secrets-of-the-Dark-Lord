using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWithFinding : Floor
{
    bool haveFinding = true;
    [SerializeField] Material emptyFindingMaterial;

    public override void OnPlayerMove(Player player)
    {
        base.OnPlayerMove(player);
        if (haveFinding)
        {
            Finding finding = Game.Instance.FindingsGenerator.GenerateFinding();
            if (finding != null)
            {
                player.Inventory.AddItem(finding.Item, finding.ItemCount);
            }

            renderer.material = emptyFindingMaterial;
            haveFinding = false;
        }
    }
}
