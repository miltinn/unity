using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject fire;

    private void Awake()
    {
        fire.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name);
        Destroy(gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Stay: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exit: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        fire.SetActive(true);
        Debug.Log("Trigger Enter: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        fire.SetActive(false);
        Debug.Log("Trigger Exit: " + other.gameObject.name);
    }
}
