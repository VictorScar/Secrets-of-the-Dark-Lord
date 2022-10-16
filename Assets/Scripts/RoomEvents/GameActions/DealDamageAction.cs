using SODL.Character;
using SODL.Core;
using UnityEngine;

namespace SODL.RoomEvents
{
    [System.Serializable]
    public class DealDamageAction : IGameAction
    {
        [SerializeField] int damage = 1;
        Player player;

        public void Run()
        {
            player = Game.Instance.TurnManager.TurnOwner as Player;
            player.Health -= damage;
            Debug.Log($"Получено урона: {damage}, Жизней осталось: {player.Health}");
        }
    }
}
