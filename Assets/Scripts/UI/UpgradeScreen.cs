using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeScreen : Panel
{
    [SerializeField] private Text _essenceScore;
    [SerializeField] private Button _firstUpgrade;
    [SerializeField] private Button _secondUpgrade;
    [SerializeField] private Button _thirdUpgrade;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerStats _playerStats;

    public PlayerStats PlayerStats => _playerStats;

    public event UnityAction<int> EssenceChanged;

    private event UnityAction UpgradeButtonClick;

    private void OnEnable()
    {
        _firstUpgrade.onClick.AddListener(OnFirstUpgrade);
    }

    private void OnDisable()
    {
        _firstUpgrade.onClick.RemoveListener(OnFirstUpgrade);
    }

    private void OnFirstUpgrade()
    {
        int firstUpgradeCost = 1;

        if (_playerStats.Essence >= 1)
        {
            _playerStats.Essence -= firstUpgradeCost;
            EssenceChanged?.Invoke(_playerStats.Essence);
            _playerStats.Health += 5;
            //HealthChanged?.Invoke(_playerStats.Health, _player.CurrentHealth);
            _playerStats.DefencePower += 2;
            //DefencePowerChanged?.Invoke(_defencePower, _currentDefencePower);
        }
    }

    public void AddEssence(int essence)
    {
        _playerStats.Essence += essence;
        EssenceChanged?.Invoke(_playerStats.Essence);
    }

    public override void Open(GameObject panel)
    {
        panel.SetActive(true);
    }

    public override void Close(GameObject panel)
    {
        panel.SetActive(false);
    }

    protected override void OnButtonClick()
    {
        UpgradeButtonClick?.Invoke();
    }    
}
