using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnValueChanged;
    }
}
