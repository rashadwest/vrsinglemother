using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    private List<GameObject> Grasses = new List<GameObject>();

    void Start()
    {
        foreach (Transform item in transform)
        {
            Grasses.Add(item.gameObject);
        }
    }

    public void Enable()
    {
        foreach (var item in Grasses)
        {
            item.GetComponent<GrassCuttingController>().enabled = true;
            item.GetComponent<GrassCuttingController>().Enabled = true;
        }
    }

    public void Disable()
    {
        foreach (var item in Grasses)
        {
            item.GetComponent<GrassCuttingController>().enabled = false;
        }
    }
}
