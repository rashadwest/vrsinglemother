using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaShiningEffect : MonoBehaviour
{
    public float Speed = 1;

    public Renderer Renderer;

    private float StartTime;

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        float shininess = Mathf.PingPong(Time.time, 0.5f);
        Renderer.materials[0].SetFloat("_Glossiness", shininess);
    }
}
