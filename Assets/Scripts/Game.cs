using SODL.ActionPoints;
using SODL.Character;
using SODL.Finding;
using SODL.RoomEvents;
using UnityEngine;

namespace SODL.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private FindingsGenerator findingsGenerator;
        [SerializeField] private EffectSystem effectSystem;
        [SerializeField] private CharacterActionManager actionManager;
        [SerializeField] private RoomEventManager roomEventManager;
        [SerializeField] private QuestionUI questionUI;
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private NpcSpawner npcSpawner;

        public static Game Instance { get; private set; }
        public Player Player { get { return player; } set { player = value; } }
        public FindingsGenerator FindingsGenerator { get { return findingsGenerator; } }
        public CharacterActionManager ActionManager { get => actionManager; }
        public RoomEventManager RoomEventManager { get => roomEventManager; }
        public PlayerCamera PlayerCamera { get => playerCamera; set => playerCamera = value; }
        public EffectSystem EffectSystem { get => effectSystem; }
        public QuestionUI QuestionUI { get => questionUI; }
        public TurnManager TurnManager { get => turnManager; }
        public NpcSpawner NpcSpawner { get => npcSpawner; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}