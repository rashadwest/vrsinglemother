using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCuttingController : MonoBehaviour
{
    private Transform Target;

    public bool Enabled = false;

    private void Start()
    {
        FindTarget();
    }

    void FindTarget() {
        Target = GameObject.FindGameObjectWithTag("LawnMower").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Enabled)
        {
            Target = GameObject.FindGameObjectWithTag("LawnMower").transform;
            if (other.transform != Target)
                return;

            Destroy(gameObject);
        }
    }
}
