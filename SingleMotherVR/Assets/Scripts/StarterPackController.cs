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
    public GameObject ExperimentPanel;
    public GameObject Sphere;
    public GameObject Canvas;
    public GameObject EnvironmentExmaple;

    public Button ContinueBtn;
    public Button ExitBtn;

    public Button LeftHandBtn;
    public Button RightHandBtn;

    public CurvedUIInputModule EventSystem;

    public CurvedUIHandSwitcher HandSwitcher;

    private void Awake()
    {
        ContinueBtn.onClick.AddListener(ShowHandsPanel);
        LeftHandBtn.onClick.AddListener(SetHandToLeft);
        RightHandBtn.onClick.AddListener(SetHandToRight);
        ExitBtn.onClick.AddListener(HidePanels);
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
        ExperimentPanel.SetActive(false);
        EnvironmentExmaple.SetActive(false);

        yield return new WaitForSeconds(2.7f);
        Title.SetActive(false);
        IntroPanel.SetActive(true);
    }

    void ShowHandsPanel() {
        IntroPanel.SetActive(false);
        ExperimentPanel.SetActive(false);
        HandsPanel.SetActive(true);
    }

    private void HidePanels() {
        Title.SetActive(false);
        IntroPanel.SetActive(false);
        HandsPanel.SetActive(false);
        ExperimentPanel.SetActive(false);
        Sphere.SetActive(false);
        Canvas.SetActive(false);
        EnvironmentExmaple.SetActive(true);
    }

    void SetHandToLeft() {
        PlayerPrefs.SetString("Hand", "left");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Left;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Left);
        HandsPanel.SetActive(false);
        ExperimentPanel.SetActive(true);
    }

    void SetHandToRight() {
        PlayerPrefs.SetString("Hand", "right");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Right;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Right);
        HandsPanel.SetActive(false);
        ExperimentPanel.SetActive(true);
    }
}
