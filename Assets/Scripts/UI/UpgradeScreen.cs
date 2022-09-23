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
    private int thirdUpgradeCost = 20;

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

    private void UpgradePlayer(int upgradeCost, PlayerStats playerStats)
    {
        if (playerStats.Essence >= upgradeCost)
        {
            playerStats.Essence -= upgradeCost;
            EssenceChanged?.Invoke(_playerStats.Essence);
        }
    }

    private void OnFirstUpgrade()
    {
        UpgradePlayer(_firstUpgradeCost, _playerStats);
        _playerStats.Health += 5;
        _playerStats.DefencePower += 2;
        _firstUpgrade.interactable = false;
    }

    private void OnSecondUpgrade()
    {
        UpgradePlayer(_secondUpgradeCost, _playerStats);
        _playerStats.Health += 5;
        _playerStats.DefencePower += 2;
        _secondUpgrade.interactable = false;
    }

    private void OnThirdUpgrade()
    {
        UpgradePlayer(thirdUpgradeCost, _playerStats);
        _playerStats.Health += 10;
        _playerStats.DefencePower += 4;
        _thirdUpgrade.interactable = false;
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
