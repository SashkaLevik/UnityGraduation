using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _topHit;
    [SerializeField] private AudioSource _middleHit;
    [SerializeField] private AudioSource _bottomHit;
    [SerializeField] private AudioSource _playerDamage;

    public AudioSource TopHit => _topHit;
    public AudioSource MiddleHit => _middleHit;
    public AudioSource BottomHit => _bottomHit;
    public AudioSource PlayerDamage => _playerDamage;
}
