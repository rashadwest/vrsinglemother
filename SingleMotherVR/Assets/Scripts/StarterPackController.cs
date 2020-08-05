using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterPackController : MonoBehaviour
{
    public GameObject Title;
    public GameObject Panel;
    public GameObject Sphere;
    public GameObject Canvas;
    public GameObject EnvironmentExmaple;

    public Button ContinueBtn;

    private void Awake()
    {
        ContinueBtn.onClick.AddListener(HidePanels);
    }

    private void Start()
    {
        StartCoroutine(StarterPanelsAnimation());
    }

    private IEnumerator StarterPanelsAnimation()
    {
        Title.SetActive(true);
        Sphere.SetActive(true);
        Canvas.SetActive(true);
        Panel.SetActive(false);
        EnvironmentExmaple.SetActive(false);

        yield return new WaitForSeconds(2.7f);
        Title.SetActive(false);
        Panel.SetActive(true);
    }

    private void HidePanels() {
        Title.SetActive(false);
        Panel.SetActive(false);
        Sphere.SetActive(false);
        Canvas.SetActive(false);
        EnvironmentExmaple.SetActive(true);
    }
}
