using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDangerArea : MonoBehaviour
{
    private Transform Target;

    public Transform Avatar;

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        ChangePosition();
    }

    void ChangePosition() {
        SceneManager.LoadScene("Beach");
    }
}
