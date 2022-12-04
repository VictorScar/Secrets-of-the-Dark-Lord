using SODL.ActionPoints;
using SODL.Cells;
using SODL.Character;
using SODL.Utils;
using UnityEngine;

namespace SODL.Core
{
    public class NpcSpawner : MonoBehaviour
    {
        Cached<TurnManager> turnManagerCached = new Cached<TurnManager>(() => Game.Instance.TurnManager);

        public void SpawnNPC(GameCharacter characterPrefab)
        {
            GameCharacter character = turnManagerCached.Value.TurnOwner;
            MoveDirection characterDirection = character.LastMoveDirection;
            //Получаем ячейку для спавна НПС по последнему направлению движения игрока
            Cell startingCell = character.CurrentCell.GetCellByDirection(characterDirection.ToDirectionType());


            if (characterPrefab != null)
            {
                GameCharacter npcCharacter = Instantiate(characterPrefab, startingCell.transform.position, Quaternion.identity);
                Debug.Log("Instantiate");
                npcCharacter.startingCell = startingCell;
                npcCharacter.RotateTo(characterDirection.Inverse());
            }
        }
    }
}