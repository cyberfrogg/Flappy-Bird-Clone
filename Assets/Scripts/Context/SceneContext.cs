using Level;
using Pausing;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static SceneContext Instance { get; private set; }

    public LevelEnviroment LevelEnviroment { get => _levelEnviroment; }
    public PlayerBird PlayerBird { get => _playerBird; }
    public GamePause GamePause { get => _gamePause; }

    [SerializeField] private LevelEnviroment _levelEnviroment;
    [SerializeField] private PlayerBird _playerBird;
    [SerializeField] private GamePause _gamePause;

    private void Awake()
    {
        Instance = this;
    }
}
