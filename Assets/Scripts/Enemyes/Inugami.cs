using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inugami : Enemy
{
    [SerializeField] private AudioSource _howl;

    private void Start()
    {
        _howl.Play();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
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
