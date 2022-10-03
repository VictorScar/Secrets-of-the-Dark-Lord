using SODL.Character;
using SODL.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SODL.ActionPoints
{
    public class TurnManager : MonoBehaviour
    {
        CharacterActionManager actionManager;

        Queue<GameCharacter> characterQueue = new Queue<GameCharacter>();
        public GameCharacter TurnOwner { get => characterQueue.Peek(); }

        private void Start()
        {
            actionManager = Game.Instance.ActionManager;
            RegisterCharacter(Game.Instance.Player);
            actionManager.onCharacterFinished += GetNextTurn;
            actionManager.StartNewTurn(TurnOwner);
        }

        public void RegisterCharacter(GameCharacter character)
        {
            characterQueue.Enqueue(character);
        }

        private void GetNextTurn()
        {
            var character = characterQueue.Dequeue();
            characterQueue.Enqueue(character);
            actionManager.StartNewTurn(TurnOwner);
        }
    }
}