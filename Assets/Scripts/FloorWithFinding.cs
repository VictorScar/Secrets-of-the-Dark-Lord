using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWithFinding : Floor
{
    bool haveFinding = true;
    [SerializeField] Item item;
    [SerializeField] int itemCount = 1;

    public override void OnPlayerMove(Player player)
    {
        base.OnPlayerMove(player);
        if (haveFinding)
        {
            player.Inventory.AddItem(item, itemCount);
        }
    }
}
