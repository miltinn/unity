using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 dir;
    public Transform shootPoint;
    public GameObject projectile;

    public PoolManager poolManager;

    public int deathNumber = 0;

    public bool canMove = false;

    public MeshRenderer meshRenderer;

    public void ChangeColor(Color c)
    {
        meshRenderer.material.SetColor("_Color", c);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (!canMove) return;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dir * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        var obj = poolManager.GetPooledObject();

        if (obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<Projectile>().StartProjectile();
            obj.GetComponent<Projectile>().OnHitTarget = CountDeaths;
            obj.transform.SetParent(null);
            obj.transform.position = shootPoint.transform.position;
        }
            //cria uma instancia de prefab, adicionando transform à ela.
            //var obj = Instantiate(projectile);

    }

    private void CountDeaths()
    {
        deathNumber++;
        Debug.Log("Deaths: " +deathNumber);
    }
}
