using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : ObjectPool
{
    [SerializeField] private GameObject[] _tamplate;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _minSpawnPosY;
    [SerializeField] private float _maxSpawnPosY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_tamplate);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject environment))
            {
                _elapsedTime = 0;
                float spawnPosY = Random.Range(_minSpawnPosY, _maxSpawnPosY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosY, transform.position.z);
                environment.SetActive(true);
                environment.transform.position = spawnPoint;
                DisableEnvironment();
            }
        }
    }
}
