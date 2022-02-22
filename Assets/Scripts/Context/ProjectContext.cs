using Level.Generation.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public static ProjectContext Instance { get; private set; }

    public ChunkFactory ChunkFactory { get => _chunkFactory; }

    [SerializeField] private ChunkFactory _chunkFactory;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
        DontDestroyOnLoad(this);
    }
}
