using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;    
    [SerializeField] private Transform _spawnPoint;    
    [SerializeField] private Player _player;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private GameScreen _gameScreen;
    
    private int _currentWaveNumber;
    private int _spawned;
    private Wave _currentWave;

    private void Start()
    {
        SetWave(_currentWaveNumber);
        SetDelay();
    }        

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemyes());
    }

    private void SetWave(int waweIndex)
    {
        _currentWave = _waves[waweIndex];                
    }

    private void SetDelay()
    {
        foreach (var wave in _waves)
        {
            wave.CurrentDelay = wave.Delay;
        }
    }

    private IEnumerator SpawnEnemyes()
    {
        var timeBetweenSpawn = new WaitForSeconds(_currentWave.CurrentDelay);
        
        for (int i = 0; i < _waves.Count; i++)
        {
            for (float k = _currentWave.CurrentDelay; k > 1; k--)
            {
                for (int j = _currentWave.EnemyesCount; j > 0; j--)
                {
                    Invoke(nameof(Spawn), _waves[0].FirstSpawnDelay);
                    NextWave();
                    yield return timeBetweenSpawn;
                }
            }
            
        }
    }    
    
    private void NextWave()
    {
        if (_currentWave.EnemyesCount <= _spawned && _waves.Count > _currentWaveNumber + 1)
        {
            _spawned = 0;
            SetWave(++_currentWaveNumber);
        }

        if (_currentWave.EnemyesCount <= _spawned)
        {
             _currentWave = null;
        }
        NextLevel();
    }             

    private void NextLevel()
    {
        if (_currentWave == null)
        {
            _currentWaveNumber = -1;
            SetWave(++_currentWaveNumber);
            _spawned = 0;

            foreach (var wave in _waves)
            {
                if (wave.CurrentDelay >= 1)
                {
                    wave.CurrentDelay--;
                }
                else
                    _currentWave = null;
            }
        }
    }

    private void NextLevel2()
    {
        if (_currentWave == null)
        {
            _currentWaveNumber = -1;
            SetWave(++_currentWaveNumber);
            _spawned = 0;

            foreach (var wave in _waves)
            {
                if (wave.CurrentDelay >= 1)
                {
                    wave.CurrentDelay--;
                }
                else
                    _currentWave = null;
            }
        }
    }
    private void Spawn()
    {        
        GameObject tamplate = _currentWave.Tamplate[Random.Range(0, _currentWave.Tamplate.Length)];
        Enemy enemy = Instantiate(tamplate, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
        _spawned++;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _upgradeScreen.AddEssence(enemy.Reward);
        _gameScreen.IncreaseKilledEnemyes(enemy.Reward);
    }        
}

[System.Serializable]
public class Wave
{
    [SerializeField] private float _firstSpawnDelay;
    [SerializeField] private int _enemyesCount;
    [SerializeField] private float _delay;
    [SerializeField] private float _currentDelay;

    public GameObject[] Tamplate;
    public float FirstSpawnDelay => _firstSpawnDelay;
    public float Delay => _delay;
    public float CurrentDelay
    {
        get => _currentDelay;
        set
        {
            if (value >= 1)
            {
                _currentDelay = value;
            }
        }
    }

    public int EnemyesCount
    {
        get => _enemyesCount;
        set
        {
            if (value > 0)
            {
                _enemyesCount = value;
            }
        }
    }
}
