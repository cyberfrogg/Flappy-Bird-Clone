﻿using System;
using UnityEngine;

namespace Core.Level
{
    public class Chunk : MonoBehaviour
    {
        public Transform StartMarker { get => _startMarker; }
        public Transform EndMarker { get => _endMarker; }

        [SerializeField] private Transform _startMarker;
        [SerializeField] private Transform _endMarker;

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
