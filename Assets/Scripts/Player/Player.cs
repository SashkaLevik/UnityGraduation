using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{        
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameObject _shield;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;

    private int _currentDefence;
    private int _currentDefencePower;
    private bool _isDefending = false;

    private Rigidbody2D _rigidbody;
    private Animator _animator;   

    public event UnityAction<int, int> DefencePowerChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentDefencePower = _upgradeScreen.PlayerStats.DefencePower;
    }

    private void Update()
    {
        if (_currentDefence == 0)
        {
            _shield.SetActive(false);
        }
    }

    public void Reset()
    {
        _health.Reset();
        _currentDefencePower = _upgradeScreen.PlayerStats.DefencePower;
        DefencePowerChanged?.Invoke(_currentDefencePower, _upgradeScreen.PlayerStats.DefencePower);
    }

    public void TakeDamage(int damage)
    {
        if (_isDefending == true)
        {
            _currentDefence -= damage;

            if (_currentDefence <= 0)
                _isDefending = false;
        }
        else
        {            
            _health.TakeDamage(damage);
        }
    }    

    public void OnDefenceButton()
    {
        if (_currentDefencePower > 0)
        {
            _isDefending = true;
            _shield.SetActive(true);
            _currentDefence = _upgradeScreen.PlayerStats.Defence;
            _currentDefencePower--;
            DefencePowerChanged?.Invoke(_currentDefencePower, _upgradeScreen.PlayerStats.DefencePower);
        }        
    }

    public void OnTopAttackButton()
    {
        _animator.SetTrigger(AnimationManager.TopHit);
        _audioManager.TopHit.Play();
    }

    public void OnMiddleAttackButton()
    {
        _animator.SetTrigger(AnimationManager.MiddleHit);
        _audioManager.MiddleHit.Play();
    }

    public void OnBottomAttackButton()
    {
        _animator.SetTrigger(AnimationManager.BottomHit);
        _audioManager.BottomHit.Play();
    }    
}
