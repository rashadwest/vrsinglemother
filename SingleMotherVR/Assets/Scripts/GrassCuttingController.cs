using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCuttingController : MonoBehaviour
{
    private Transform Target;

    private void Start()
    {
        StartCoroutine(FindTarget());
    }

    IEnumerator FindTarget() {
        yield return new WaitForSeconds(1);
        Target = GameObject.FindGameObjectWithTag("LawnMower").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
