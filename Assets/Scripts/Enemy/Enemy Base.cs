using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IKillable, IDamageable<int>
{
        public EnemyData enemyData;

    private int _currentLife;

    private void Awake()
    {
        Init();
    }

    #region CODE
    protected virtual void Init()
    {
        _currentLife = enemyData.startLife;
    }

    public virtual void Attack()
    {
        Debug.Log("Attack: ");
    }

    public virtual void OnDamage() { }
    #endregion

    #region INTERFACES
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Damage(int f)
    {
        _currentLife -= f;
        transform.localScale *= 0.9f;

        OnDamage();

        if(_currentLife <= 0) Kill();
    }
    #endregion
}
