using System;
using UnityEngine;

public class YardWorkEndTrigger : MonoBehaviour
{
    private Transform Target;

    public Action Callback;

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        Callback.Invoke();
    }
}
