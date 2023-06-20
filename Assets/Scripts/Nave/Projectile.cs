using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToReset = 5f;
    public Vector3 dir;

    public string tagToLook = "Enemy";

    public Action OnHitTarget;

    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    public void StartProjectile()
    {
        //Destroy(gameObject, timeToDestroy); //destruir depois de x segundos
        Invoke(nameof(FinishUsage), timeToReset);
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false); //devolve o objeto para a pool
        OnHitTarget = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToLook)
        {
            Destroy(collision.gameObject); //destroi alvo
            OnHitTarget?.Invoke(); //se houver função, chama ela
            FinishUsage();
        }
    }

}
