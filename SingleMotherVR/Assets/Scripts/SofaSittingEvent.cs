using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaSittingEvent : MonoBehaviour
{
    private Transform Target;

    public MainEngine Engine;

    public ShiningEffect SofaShiningEffect;


    private void Start()
    {
        Target = Camera.main.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        Sitting();
    }

    void Sitting() {
        SofaShiningEffect.EndShining();
        Engine.SittingSofa();
    }
}
