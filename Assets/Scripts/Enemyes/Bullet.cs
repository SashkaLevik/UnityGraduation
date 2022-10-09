using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private const string EyeBullet = "EyeBullet";
    private const string FireBullet = "FireBullet";

    private Player _target;
    private Animator _animator;

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _animator.Play(EyeBullet);
        _animator.Play(FireBullet);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
