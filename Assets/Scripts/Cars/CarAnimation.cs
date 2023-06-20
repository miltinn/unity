using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarAnimation : MonoBehaviour
{
    public float duration = 2;
    public Ease ease = Ease.Linear;
    // Start is called before the first frame update
    void Start()
    {
        //se move até X = 0, com duração de <duration>, usando o EASE <ease>
        transform.DOMoveX(0,duration).SetEase(ease);
        //transform.DOMove(new Vector3((float)-1.72000003, (float)-0.878848314, (float)-10.3500004), 2);
    }
}
