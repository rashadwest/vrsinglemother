using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningEffect : MonoBehaviour
{
    public float Speed = 1;

    public Renderer Renderer;

    private float StartTime;

    private bool isEnded = false;

    public int MaterialID = 0;

    public string MaterialOptionName = "_Glossiness";

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        if (!isEnded)
        {
            float shininess = Mathf.PingPong(Time.time, 1f);
            Renderer.materials[MaterialID].SetFloat(MaterialOptionName, shininess);
        }
    }

    public void EndShining() {
        isEnded = true;
        Renderer.materials[MaterialID].SetFloat(MaterialOptionName, 0);
    }

    public void StartShining() {
        isEnded = false;
    }
}
