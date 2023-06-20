using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MeuJogo.Bus.Manager;

public enum Animals
{
    Dog,
    Cat,
    Fish
}

public class ScriptTest : MonoBehaviour
{
    public UnityEvent eventCallback;

    public EnemyBase enemyBase;

    public List<GameObject> listOfObjects;

    private void Attack()
    {
        foreach (var o in listOfObjects)
        {
            if (o != null)
            {
                var damageable = o.GetComponent<IDamageable<int>>();
                if (damageable != null)
                {
                    damageable.Damage(1);
                }
            }
        }
    }

    public void DebugLog()
    {
        Debug.Log("Cliquei no botão");
    }



    public bool checkStatus = false;

    public List<AnimalSetup> animalSetup;

    private void checkSwitchCase(Animals a)
    {
        switch(a)
        {
            case Animals.Dog:
                OnReadDog();
                break;
            case Animals.Cat:
                OnReadCat();
                break;
            case Animals.Fish:
                OnReadFish();
                break;
        }
    }

    private void checkKeys()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            eventCallback?.Invoke();
            //checkSwitchCase(Animals.Dog);
            ShowTextByAnimal(Animals.Dog);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            enemyBase.Attack();
            //checkSwitchCase(Animals.Cat);
            ShowTextByAnimal(Animals.Cat);
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Attack();
            //checkSwitchCase(Animals.Fish);
            ShowTextByAnimal(Animals.Fish);
        }
    }

    private void ShowTextByAnimal(Animals a)
    {
        foreach (var animal in animalSetup)
        {
            if (animal.animalType == a)
                Debug.Log(animal.text);
        }
    }
    #region READ ANIMALS
    private void OnReadDog()
    {
        foreach (var animal in animalSetup)
        {
            if(animal.animalType == Animals.Dog)
                Debug.Log(animal.text);
        }
    }
    private void OnReadCat()
    {
        foreach (var animal in animalSetup)
        {
            if (animal.animalType == Animals.Cat)
                Debug.Log(animal.text);
        }
    }
    private void OnReadFish()
    {
        foreach (var animal in animalSetup)
        {
            if (animal.animalType == Animals.Fish)
                Debug.Log(animal.text);
        }
    }
    #endregion
    private void Update()
    {
        //checkSwitchCase();
        checkKeys();

    }

    [System.Serializable]
    public class AnimalSetup
    {
        public Animals animalType;
        public string text;
    }
}
