using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private GameObject _hit;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Player _player;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<Player> PlayerDied;

    private void Start()
    {
        _currentHealth = _upgradeScreen.PlayerStats.Health;
    }

    public void ResetHealth()
    {
        _currentHealth = _upgradeScreen.PlayerStats.Health;
        HealthChanged?.Invoke(_currentHealth, _upgradeScreen.PlayerStats.Health);
    }

    public void TakeDamage(int damage)
    {
        _hit.SetActive(true);
        _audioManager.PlayerDamage.Play();
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _upgradeScreen.PlayerStats.Health);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            PlayerDied?.Invoke(_player);
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
    }
}
