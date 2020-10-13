using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenMissionController : MonoBehaviour
{
    [Header("Start")]
    public GameObject Particle;
    public Transform Avatar;
    public CharacterController AvatarController;
    private Transform Target;

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != Target.transform)
            return;

        Debug.LogError("Start Kitchen Mission");
    }
}
