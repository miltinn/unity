using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 forceDirection;

    private void SpawnObject()
    {
        //cria uma instancia de prefab, adicionando transform à ela.
        var obj = Instantiate(prefab, transform);
        //Adiciona um valor de força ao objeto.
        obj.GetComponent<Rigidbody>().AddForce(forceDirection);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }
}
