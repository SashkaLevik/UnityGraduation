using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledEnemyesCount : MonoBehaviour
{
    [SerializeField] private Text _enemyesKilled;
    [SerializeField] private GameScreen _gameScreen;

    private void OnEnable()
    {
        _gameScreen.EnemyesKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _gameScreen.EnemyesKilled -= OnEnemyKilled;
    }

    public void OnEnemyKilled(int enemy)
    {
        _enemyesKilled.text = enemy.ToString();
    }
}
