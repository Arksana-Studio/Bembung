﻿using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GamePrefabs _gamePrefabs;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gamePrefabs = GamePrefabs.Instance;

        foreach (GameObject o in _gamePrefabs.ringSpawnPositionList)
        {
            GameObject spawnedObject = Instantiate(_gamePrefabs.ringPrefab, o.transform.position,
                Quaternion.identity * Quaternion.Euler(30,90, 0),
                _gamePrefabs.ringsParent.transform);
            spawnedObject.TryGetComponent(out Rigidbody component);
            _gamePrefabs.ringRigidbodyList.Add(component);
        }
    }
}