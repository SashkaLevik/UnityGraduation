using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Button _topAttackButton;
    [SerializeField] private Button _middleAttackButton;
    [SerializeField] private Button _bottomAttackButton;
    [SerializeField] private Button _defenceButton;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _topAttackButton.onClick.AddListener(_player.OnTopAttackButton);
        _middleAttackButton.onClick.AddListener(_player.OnMiddleAttackButton);
        _bottomAttackButton.onClick.AddListener(_player.OnBottomAttackButton);
        _defenceButton.onClick.AddListener(_player.OnDefenceButton);
    }

    private void OnDisable()
    {
        _topAttackButton.onClick.RemoveListener(_player.OnTopAttackButton);
        _middleAttackButton.onClick.RemoveListener(_player.OnMiddleAttackButton);
        _bottomAttackButton.onClick.RemoveListener(_player.OnBottomAttackButton);
        _defenceButton.onClick.RemoveListener(_player.OnDefenceButton);
    }
}
