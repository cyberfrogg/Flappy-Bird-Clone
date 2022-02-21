using System;
using UnityEngine;
using Zenject;

namespace Level.Generation
{
    [RequireComponent(typeof(LevelEnviroment))]
    public class LevelGenerator : MonoBehaviour
    {
        [Inject] private ChunkFactory _factory;
        private LevelEnviroment _enviroment;

        private void Awake()
        {
            _enviroment = GetComponent<LevelEnviroment>();
        }

        private void Start()
        {

        }
    }
}