using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyes : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;    
    [SerializeField] private Transform _spawnPoint;    
    [SerializeField] private Player _player;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    

    private Wave _currentWave;
    private int _currentWaveNumber;
    private int _spawned;
    private float _timeAfterLastSpawn;    

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantieteEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        NextWave();
    }    

    public void SetWave(int waweIndex)
    {
        _currentWave = _waves[waweIndex];
    }

    private void NextWave()
    {
        if (_currentWave.EnemyesCount <= _spawned && _waves.Count > _currentWaveNumber + 1)
        {
            SetWave(++_currentWaveNumber);
            _spawned = 0;            
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
                if (wave.Delay > 1)
                {
                    wave.Delay--;
                }
                else
                    _currentWave = null;
            }
        }        
    }

    private void InstantieteEnemy()
    {
        GameObject tamplate = _currentWave.Tamplate[Random.Range(0, _currentWave.Tamplate.Length)];
        Enemy enemy = Instantiate(tamplate, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);

        enemy.Dying += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _upgradeScreen.AddEssence(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] Tamplate;
    [SerializeField] private int _enemyesCount;
    [SerializeField] private float _delay;

    public float Delay
    {
        get => _delay;
        set
        {
            if (value > 1)
            {
                _delay = value;
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
