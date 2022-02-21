using System;
using UnityEngine;

namespace Level.Generation
{
    public class ChunkFactory : MonoBehaviour
    {
        [SerializeField] private Chunk[] _prefabs;

        private System.Random _random = new System.Random();

        public Chunk CreateRandom()
        {
            Chunk instance = Instantiate(getRandom());
            instance.transform.position = Vector3.zero;
            return instance;
        }

        private Chunk getRandom()
        {
            return _prefabs[_random.Next(0, _prefabs.Length)];
        }
    }
}
