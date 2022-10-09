using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maikubi : Enemy
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _mumbling;



    private void Start()
    {
        _mumbling.Play();
        Invoke(nameof(Attack) , 1f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(EnemyDamage);
            Die();
        }
    }

    private void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint.position, Quaternion.identity);
    }

    protected override void Attack()
    {
        Shoot(_shootPoint);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
