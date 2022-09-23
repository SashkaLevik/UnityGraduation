using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceCount : MonoBehaviour
{
    [SerializeField] private Text _essenceScore;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    private void OnEnable()
    {
        _upgradeScreen.EssenceChanged += OnEssenceChanged;
    }

    private void OnDisable()
    {
        _upgradeScreen.EssenceChanged -= OnEssenceChanged;
    }

    public void OnEssenceChanged(int essence)
    {
        _essenceScore.text = essence.ToString();
    }
}
