using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceCount : MonoBehaviour
{
    [SerializeField] private Text _essenceScore;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private PlayerStats _playerStats;

    private void Update()
    {
        _essenceScore.text = _playerStats.Essence.ToString();
    }

    //private void OnEnable()
    //{
    //    _upgradeScreen.EssenceChanged += OnEssenceChanged;
    //}

    //private void OnDisable()
    //{
    //    _upgradeScreen.EssenceChanged -= OnEssenceChanged;
    //}

    //public void OnEssenceChanged(int essence)
    //{
    //    _essenceScore.text = essence.ToString();
    //}
}
