using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeScreen : Panel
{
    [SerializeField] private Button _firstUpgrade;
    [SerializeField] private Button _secondUpgrade;
    [SerializeField] private Button _thirdUpgrade;
    [SerializeField] private PlayerStats _playerStats;

    private int _firstUpgradeCost = 5;
    private int _secondUpgradeCost = 10;
    private int _thirdUpgradeCost = 20;
    private int _healthUpgrade = 5;
    private int _defenceUpgrade = 2;

    public PlayerStats PlayerStats => _playerStats;

    public event UnityAction<int> EssenceChanged;
    private event UnityAction UpgradeButtonClick;

    private void OnEnable()
    {
        _firstUpgrade.onClick.AddListener(OnFirstUpgrade);
        _secondUpgrade.onClick.AddListener(OnSecondUpgrade);
        _thirdUpgrade.onClick.AddListener(OnThirdUpgrade);
    }

    private void OnDisable()
    {
        _firstUpgrade.onClick.RemoveListener(OnFirstUpgrade);
        _secondUpgrade.onClick.RemoveListener(OnSecondUpgrade);
        _thirdUpgrade.onClick.RemoveListener(OnThirdUpgrade);
    }    

    private bool TryUpgradePlayer(int upgradeCost, PlayerStats playerStats)
    {
        if (playerStats.Essence >= upgradeCost)
        {
            playerStats.Essence -= upgradeCost;
            EssenceChanged?.Invoke(_playerStats.Essence);
            playerStats.Health += _healthUpgrade;
            playerStats.DefencePower += _defenceUpgrade;
            return true;
        }
        return false;
    }

    private void OnFirstUpgrade()
    {
        if (TryUpgradePlayer(_firstUpgradeCost, _playerStats))
        {
            _firstUpgrade.interactable = false;
        }
    }

    private void OnSecondUpgrade()
    {
        if (TryUpgradePlayer(_secondUpgradeCost, _playerStats))
        {
            _secondUpgrade.interactable = false;
        }
    }

    private void OnThirdUpgrade()
    {
        if (TryUpgradePlayer(_thirdUpgradeCost, _playerStats))
        {
            _thirdUpgrade.interactable = false;
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
