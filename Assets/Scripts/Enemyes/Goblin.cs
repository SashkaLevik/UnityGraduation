using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _yokaiScream;

    private float _lastAttackTime;
    private float _attackRecoil = -8;

    protected override void Attack()
    {
        Shoot(_shootPoints);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }   

    private void Update()
    {
        float targetDistance = Vector2.Distance(transform.position, Target.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        //StartCoroutine(GoblinMover());
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = Delay;
        }
        if (targetDistance < _attackRange)
        {


            _lastAttackTime -= Time.deltaTime;
        }
    }

    //private IEnumerator GoblinMover()
    //{
    //    var waitTwoSeconds = new WaitForSeconds(2f);
    //    yield return waitTwoSeconds;
    //    transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(EnemyDamage);
            Die();
        }
    }    

    private void Shoot(Transform[] shootPoints)
    {
        for (int i = 0; i < shootPoints.Length; i++)
        {
            Instantiate(_bullet, shootPoints[i].position, Quaternion.identity);
        }
    }
}
