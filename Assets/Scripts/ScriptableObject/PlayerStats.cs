using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerStats", menuName ="PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _defence;
    [SerializeField] private int _defencePower;
    [SerializeField] private int _essence;
    
    public int Damage => _damage;
    public int Defence => _defence;
    public int DefencePower
    {
        get => _defencePower;
        set
        {
            if (value > 0)
            {
                _defencePower = value;
            }
        }
    }
    public int Health
    {
        get => _health;
        set
        {
            if (value > 0)
            {
                _health = value;
            }
        }
    }
    public int Essence
    {
        get => _essence;
        set
        {
            if (value >= 0)
            {
                _essence = value;
            }
        }
    }    
}
