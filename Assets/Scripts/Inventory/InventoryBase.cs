using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryBase : MonoBehaviour
{
    public List<GameObject> myObjects; //itens do inventario

    public float delayBetweenObjects = .03f;
    public float animationDuration = .3f;

    [Header("Animation")]
    public Animator animator;

    public string triggerShow = "Show";
    public string triggerHide = "Hide";

    private bool _isShowing = false;

    private void Awake()
    {
        //GetObjects();
        Hide();
    }

    private void GetObjects() //obtem objetos da lista via código (equivalente a adicionalos na Unity, porém mais custoso
    {
        foreach(Transform t in GetComponentInChildren<Transform>())
        {
            if(t != transform)
                myObjects.Add(t.gameObject);
        }
    }

    private void Hide()
    {
        _isShowing = false;
        foreach (GameObject g in myObjects)
        {
            g.SetActive(false);
        }
    }

    public void ShowItems()
    {
        if (_isShowing)
        {
            Hide();
            animator.SetTrigger(triggerHide);
        } else {
            animator.SetTrigger(triggerShow);
            _isShowing = true;
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        foreach (GameObject g in myObjects)
        {
            yield return new WaitForSeconds(delayBetweenObjects);
            g.SetActive(true);
            g.transform.DOScale(0, animationDuration).From(); //aumenta a escala do objeto de 0 para o valor inicial
        }
    }
}
