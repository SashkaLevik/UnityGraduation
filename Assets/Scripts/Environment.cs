using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Vector2 _direction;
    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
