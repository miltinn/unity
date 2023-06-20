using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : EnemyBase
{
    [Header("Enemy Run")]
    public float speed;

    private void Awake()
    {
        Attack();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Attack run");
    }
}
