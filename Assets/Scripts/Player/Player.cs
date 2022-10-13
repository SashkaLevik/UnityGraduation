using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{    
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _topAttackPoint;
    [SerializeField] private Transform _middleAttackPoint;
    [SerializeField] private Transform _bottomAttackPoint;
    [SerializeField] private LayerMask _topEnemyLayer;
    [SerializeField] private LayerMask _middleEnemyLayer;
    [SerializeField] private LayerMask _bottomEnemyLayer;
    [SerializeField] private GameObject _shield;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Health _health;

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

    public void ResetPlayer()
    {
        _health.ResetHealth();
        _currentDefencePower = _playerStats.DefencePower;
        DefencePowerChanged?.Invoke(_currentDefencePower, _playerStats.DefencePower);
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

    private void PlayerAttack(Transform attackPoint, LayerMask enemy)
    {
        Collider2D[] hitEnemyes = Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, enemy);

        for (int i = 0; i < hitEnemyes.Length; i++)
        {
            hitEnemyes[i].GetComponent<Enemy>().TakeDamage(_playerStats.Damage);
        }
    }

    private void OnTopAttack()
    {
        PlayerAttack(_topAttackPoint, _topEnemyLayer);
    }    

    private void OnMiddleAttack()
    {
        PlayerAttack(_middleAttackPoint, _middleEnemyLayer);
    }

    private void OnBottomAttack()
    {
        PlayerAttack(_bottomAttackPoint, _bottomEnemyLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_topAttackPoint.position, _attackRange);
    }

}
