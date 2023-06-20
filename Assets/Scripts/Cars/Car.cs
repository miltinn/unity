using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    #region VARIABLES
    private int doors = 4;

    [Header("Variables")]
    public float life = 10f;
    public float damage = 0.5f;

    protected bool canAcelerate = false;

    [Header("Colors")]
    public Color color = Color.red;

    [Header("Inputs")]
    public KeyCode keyCode = KeyCode.Space;

    private GameObject _myObjeto;
    private Transform _myTransform;
    #endregion

    public void ChangeColor(Color newColor)
    {
        color = newColor;
        life -= damage;
    }

    public void Test(int i)
    {
        Debug.Log("Test");
    }

    public void Accelerate()
    {
        canAcelerate= true;
    }

    #region METHODS
    private void Awake()
    {
        Debug.Log("Awakened");
    }

    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode)) {
            Debug.Log("SPACE");
            ChangeColor(Color.yellow);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
        } else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }
    }
    #endregion
}
