using CurvedUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterPackController : MonoBehaviour
{
    public GameObject Title;
    public GameObject IntroPanel;
    public GameObject HandsPanel;
    public GameObject Sphere;
    public GameObject Canvas;
    public GameObject MenuPack;

    public Button ContinueBtn;

    public Button LeftHandBtn;
    public Button RightHandBtn;

    public CurvedUIInputModule EventSystem;

    public CurvedUIHandSwitcher HandSwitcher;

    private void Awake()
    {
        ContinueBtn.onClick.AddListener(ShowHandsPanel);
        LeftHandBtn.onClick.AddListener(SetHandToLeft);
        RightHandBtn.onClick.AddListener(SetHandToRight);
    }

    private void Start()
    {
        StartCoroutine(StarterPanelsAnimation());
        PlayerPrefs.SetString("Hand", "left");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Left;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Left);
    }

    private IEnumerator StarterPanelsAnimation()
    {
        Title.SetActive(true);
        Sphere.SetActive(true);
        Canvas.SetActive(true);
        IntroPanel.SetActive(false);
        HandsPanel.SetActive(false);
        MenuPack.SetActive(false);

        yield return new WaitForSeconds(2.7f);
        Title.SetActive(false);
        IntroPanel.SetActive(true);
    }

    void ShowHandsPanel() {
        IntroPanel.SetActive(false);
        HandsPanel.SetActive(true);
    }

    private void HidePanels() {
        Title.SetActive(false);
        IntroPanel.SetActive(false);
        HandsPanel.SetActive(false);
        Sphere.SetActive(false);
        Canvas.SetActive(false);
        MenuPack.SetActive(true);
    }

    void SetHandToLeft() {
        PlayerPrefs.SetString("Hand", "left");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Left;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Left);
        HidePanels();
    }

    void SetHandToRight() {
        PlayerPrefs.SetString("Hand", "right");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Right;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Right);
        HidePanels();
    }
}
