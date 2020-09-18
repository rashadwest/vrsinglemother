using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaSittingEvent : MonoBehaviour
{
    private Transform Target;

    private void Start()
    {
        Target = Camera.main.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != Target)
            return;

    }
}
