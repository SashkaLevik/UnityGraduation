using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _topAttackPoint;
    [SerializeField] private Transform _middleAttackPoint;
    [SerializeField] private Transform _bottomAttackPoint;
    [SerializeField] private LayerMask _topEnemyLayer;
    [SerializeField] private LayerMask _middleEnemyLayer;
    [SerializeField] private LayerMask _bottomEnemyLayer;
    [SerializeField] private UpgradeScreen _upgradeScreen;      

    private void PlayerAttack(Transform attackPoint, LayerMask enemy)
    {
        Collider2D[] hitEnemyes = Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, enemy);

        for (int i = 0; i < hitEnemyes.Length; i++)
        {
            hitEnemyes[i].GetComponent<Enemy>().TakeDamage(_upgradeScreen.PlayerStats.Damage);
        }
    }

    private void OnTopAttack()
    {
        PlayerAttack(_topAttackPoint, _topEnemyLayer);
    }

    private void OnMiddleAttack()
    {
        PlayerAttack(_middleAttackPoint, _middleEnemyLayer);
    }

    private void OnBottomAttack()
    {
        PlayerAttack(_bottomAttackPoint, _bottomEnemyLayer);
    }
}
