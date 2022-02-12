﻿using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _tilesPrefabs;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private int _startTiles;
        [SerializeField] private float _threshold;
        private List<GameObject> _tileList = new List<GameObject>();
        private float _spawnPos;
        private float _deletePos;

        private void Start()
        {
            for (int i = 0; i < _startTiles; i++)
            {
                SpawnTile();
            }

            CalculateDeletePosition();
        }
        //TODO: pool list 
        private void Update()
        {
            if (_playerTransform.position.z - _threshold > _deletePos)
            {
                SpawnTile();
                DeleteTile();
            }
        }

        private void SpawnTile()
        {
            var tilePrefab = _tilesPrefabs[Random.Range(0, _tilesPrefabs.Length)];
            var newTile = Instantiate(tilePrefab, transform.forward * _spawnPos, Quaternion.identity);
            _tileList.Add(newTile);
            _spawnPos += newTile.transform.localScale.z;
        }

        private void DeleteTile()
        {
            Destroy(_tileList[0]);
            _tileList.RemoveAt(0);
            CalculateDeletePosition();
        }

        private void CalculateDeletePosition()
        {
            _deletePos += _tileList[0].transform.localScale.z;
        }
    }
}