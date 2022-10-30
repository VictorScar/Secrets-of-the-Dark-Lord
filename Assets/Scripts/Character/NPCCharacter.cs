using SODL.Cells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Character
{
    public class NPCCharacter : GameCharacter
    {
        private void Start()
        {
            AIController controller = GetComponent<AIController>();
        }

        public Cell SpawnNpc(Player player)
        {
            Floor floor = null;
            floor = player.CurrentCell.GetLeftCell() as Floor;

            if (floor == null)
            {
                floor = player.CurrentCell.GetRightCell() as Floor;

                if (floor == null)
                {
                    floor = player.CurrentCell.GetUpperCell() as Floor;

                    if (floor == null)
                    {
                        floor = player.CurrentCell.GetBottomCell() as Floor;
                    }
                }
            }
            else startingCell = floor;
            return startingCell;


        }
    }
}