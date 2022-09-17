using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.DefencePowerChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.DefencePowerChanged -= OnValueChanged;
    }
}
