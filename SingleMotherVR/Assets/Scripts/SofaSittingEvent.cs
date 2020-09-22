using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaSittingEvent : MonoBehaviour
{
    private Transform Target;

    public MainEngine Engine;

    public SofaShiningEffect SofaShiningEffect;


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

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != Target)
            return;

    }

    void Sitting() {
        SofaShiningEffect.EndShining();
        Engine.SittingSofa();
    }
}
