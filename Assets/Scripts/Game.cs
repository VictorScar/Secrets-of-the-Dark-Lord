using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private FindingsGenerator findingsGenerator;

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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
