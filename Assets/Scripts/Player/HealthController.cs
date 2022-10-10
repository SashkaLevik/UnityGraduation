using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private PlayerStats _playerStats;

    private int _currentHealth;
    private int _currentDefence;
    private int _currentDefencePower;
    private bool _isDefending = false;

    public int CurrentHealth => _currentHealth;

    public int CurrentDefence => _currentDefence;

    public int CurrentDefencePower => _currentDefencePower;

    public bool IsDefending => _isDefending;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> DefencePowerChanged;
    public event UnityAction<Player> PlayerDied;

    private void Start()
    {
        _currentHealth = _upgradeScreen.PlayerStats.Health;
        _currentDefencePower = _upgradeScreen.PlayerStats.DefencePower;
    }
}
