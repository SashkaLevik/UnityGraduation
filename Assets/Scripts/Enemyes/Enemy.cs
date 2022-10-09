using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward;
    [SerializeField] private float _delay;   
    [SerializeField] protected float Speed;

    private Player _target;
    private Animator _animator;

    public int Reward => _reward;
    public int EnemyDamage => _damage;
    public float Delay => _delay;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;   

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }    

    public void Init(Player target)
    {
        _target = target;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Die();
        }
    }

    protected abstract void Die();
    protected abstract void Attack();
}
