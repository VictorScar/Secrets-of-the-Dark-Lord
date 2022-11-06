using SODL.Character;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.RoomEvents
{
    [System.Serializable]
    public class NPCSpawnAction : IGameAction
    {
        [SerializeField] GameCharacter characterPrefab;

        public void Run()
        {
            Game.Instance.NpcSpawner.SpawnNPC(characterPrefab);
        }
    }
}