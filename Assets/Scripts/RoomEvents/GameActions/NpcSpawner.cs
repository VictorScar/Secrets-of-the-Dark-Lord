using SODL.ActionPoints;
using SODL.Cells;
using SODL.Character;
using SODL.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.Core
{
    public class NpcSpawner : MonoBehaviour
    {
        Cached<TurnManager> turnManagerCached = new Cached<TurnManager>(() => Game.Instance.TurnManager);

        public void SpawnNPC(GameCharacter characterPrefab)
        {
            Player player = turnManagerCached.Value.TurnOwner as Player;
            MoveDirection playerDirection = player.LastMoveDirection;
            //Получаем ячейку для спавна НПС по последнему направлению движения игрока
            Cell startingCell = player.CurrentCell.GetCellByDirection(playerDirection.ToDirectionType());


            if (characterPrefab != null)
            {
                GameCharacter npcCharacter = Instantiate(characterPrefab, startingCell.transform.position, Quaternion.identity);
                Debug.Log("Instantiate");
                npcCharacter.startingCell = startingCell;
                npcCharacter.RotateTo(playerDirection.Inverse());
            }
        }
    }
}