using SODL.Character;
using SODL.Finding;
using UnityEngine;

namespace SODL.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private FindingsGenerator findingsGenerator;
        [SerializeField] private EffectSystem effectSystem;

        public static Game Instance { get; private set; }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public FindingsGenerator FindingsGenerator
        {
            get { return findingsGenerator; }
        }

        public PlayerCamera PlayerCamera { get => playerCamera; set => playerCamera = value; }
        public EffectSystem EffectSystem { get => effectSystem; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}