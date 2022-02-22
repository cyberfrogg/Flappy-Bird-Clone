using Core.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private ChunkFactory _factory;
        [SerializeField] private Transform _levelContainer;
        [Space]
        [SerializeField, Range(10, 40)] private float _newChunkDistance = 20;
        [SerializeField, Range(0, 40)] private float _destroyChunkDistance = 20;

        private PlayerBird _playerBird;
        private List<Chunk> _chunks = new List<Chunk>();

        public void Setup(PlayerBird bird)
        {
            _playerBird = bird;
            createNewChunk(true);
        }
        private void Update()
        {
            if (_playerBird.transform.position.x > _chunks.Last().EndMarker.position.x - _newChunkDistance)
            {
                createNewChunk();
            }

            if (_playerBird.transform.position.x > _chunks.First().EndMarker.position.x + _destroyChunkDistance)
            {
                destroyFarestChunk();
            }
        }

        private void createNewChunk()
        {
            createNewChunk(false);
        }
        private void createNewChunk(bool first)
        {
            Chunk newChunk = first ? _factory.CreateFirstChunk() : _factory.CreateRandom();
            newChunk.transform.SetParent(_levelContainer);

            newChunk.transform.position = _chunks.Count() != 0 ? _chunks.Last().EndMarker.position - newChunk.StartMarker.position : Vector3.zero;

            _chunks.Add(newChunk);
        }
        private void destroyFarestChunk()
        {
            Chunk chunkToDestroy = _chunks.First();
            _chunks.Remove(chunkToDestroy);
            chunkToDestroy.Destroy();
        }
    }
}