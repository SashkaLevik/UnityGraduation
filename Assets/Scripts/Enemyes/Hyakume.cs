using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyakume : Enemy
{
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _roar;

    private float _lastAttackTime;

    private void Start()
    {
        _roar.Play();
        Invoke(nameof(Attack), 1f);
        Invoke(nameof(Die), 2f);
    }    

    protected override void Attack()
    {
        Shoot(_shootPoints);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
    
    private void Shoot(Transform[] shootPoints)
    {
        for (int i = 0; i < shootPoints.Length; i++)
        {
            Bullet bullet =  Instantiate(_bullet, shootPoints[i].position, Quaternion.identity);
            bullet.Init(Target);
        }
    }
}
