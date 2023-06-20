using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public int door = 2;
    public Color color = Color.yellow;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        BusBase myBus = new BusBase(4, Color.blue);
    }
}

public class BusBase
{
    public int door = 2;
    public Color color = Color.yellow;
    public BusBase() //Nesse caso BusBase é um construtor
    {
        Debug.Log("Construtor");
    }

    public BusBase(int door)
    {
        this.door = door;
    }

    public BusBase(int door, Color color)
    {
        this.door = door;
        this.color = color;
    }
}