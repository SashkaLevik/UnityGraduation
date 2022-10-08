using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagari : Enemy
{
    [SerializeField] private AudioSource _neigh;

    private void Start()
    {
        _neigh.Play();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    protected override void Attack()
    {
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(EnemyDamage);
            Die();
        }
    }
}
