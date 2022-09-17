using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnoll : Enemy
{
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(EnemyDamage);
            Die();
        }
    }
    protected override void Attack()
    {
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
