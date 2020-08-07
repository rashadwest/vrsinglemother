using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject DarkBGCanvas;
    public GameObject DarkSphere;

    public void Open() {
        DarkBGCanvas.SetActive(true);
        StartCoroutine(Opening());
    }

    IEnumerator Opening() {
        yield return new WaitForSeconds(0.4f);
        DarkSphere.SetActive(true);
        DarkBGCanvas.SetActive(false);
    }
}
