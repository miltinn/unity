using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour, IKillable, IDamageable<int>
{
    public int life;
    [SerializeField] private float force;

    private int _currentLife;

    private void Awake()
    {
        Init();
    }

    #region CODE
    protected virtual void Init()
    {
        _currentLife = life;
    }

    public virtual void Attack()
    {
        Debug.Log("Attack: " + force);
    }
    #endregion

    #region INTERFACES
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Damage(int f)
    {
        _currentLife -= f;
        if (_currentLife <= 0) Kill();
        transform.localScale *= 0.9f;
    }
    #endregion

}
