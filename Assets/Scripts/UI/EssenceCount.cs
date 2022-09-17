using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceCount : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _essenceScore;

    private void OnEnable()
    {
        _player.EssenceChanged += OnEssenceChanged;
    }

    private void OnDisable()
    {
        _player.EssenceChanged -= OnEssenceChanged;
    }

    public void OnEssenceChanged(int essence)
    {
        _essenceScore.text = essence.ToString();
    }
}
