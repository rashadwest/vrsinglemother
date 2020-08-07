using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    public GameObject DarkBGCanvas;
    public GameObject DarkSphere;
    public GameObject Canvas;

    public CreditsSponsorsSidePanels leftPanel;
    public CreditsSponsorsSidePanels RightPanel;

    public MenuController Menu;

    public Button ExitBtn;

    private void Awake()
    {
        ExitBtn.onClick.AddListener(GoToMenu);
    }

    public void Open() {
        DarkBGCanvas.SetActive(true);
        leftPanel.HideAll();
        RightPanel.HideAll();
        leftPanel.gameObject.SetActive(false);
        RightPanel.gameObject.SetActive(false);
        StartCoroutine(Opening());
    }

    IEnumerator Opening() {
        yield return new WaitForSeconds(0.4f);
        DarkSphere.SetActive(true);
        DarkBGCanvas.SetActive(false);
        yield return new WaitForSeconds(1);
        Canvas.SetActive(true);
        StartCoroutine(ShowingPanels());
    }

    IEnumerator ShowingPanels() {
        yield return new WaitForSeconds(2.5f);
        leftPanel.gameObject.SetActive(true);
        StartCoroutine(leftPanel.Show());
        yield return new WaitForSeconds(6.5f);
        RightPanel.gameObject.SetActive(true);
        StartCoroutine(RightPanel.Show());
    }

    void GoToMenu() {
        leftPanel.HideAll();
        RightPanel.HideAll();
        Canvas.SetActive(false);
        DarkSphere.SetActive(false);
        Menu.SimpleOpen();
    }
}
