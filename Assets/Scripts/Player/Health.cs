using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UpgradeScreen _upgradeScreen;

    private int _currentHealth;    

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value >= 0)
            {
                _currentHealth = value;
            }
        }
    }

    private void Start()
    {
        _currentHealth = _upgradeScreen.PlayerStats.Health;
    }
}
