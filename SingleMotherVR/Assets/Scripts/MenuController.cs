using CurvedUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button PlayBtn;
    public Button SettingsBtn;
    public Button CreditsBtn;
    public Button ExitBtn;

    public GameObject Container;
    public GameObject Trailer;
    public GameObject MenuContainer;
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject DarkBGCanvas;
    public GameObject Canvas;

    [Header("Settings")]
    public Button CloseSettingsBtn;
    public Button LeftHandBtn;
    public Button RightHandBtn;
    public Button BreathOnBtn;
    public Button BreathOffBtn;

    public CurvedUIInputModule EventSystem;

    public CurvedUIHandSwitcher HandSwitcher;

    [Header("Credits")]
    public CreditsController CreditsController;

    private void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    private void Awake()
    {
        PlayBtn.onClick.AddListener(Play);
        SettingsBtn.onClick.AddListener(OpenSettingsPanel);
        CreditsBtn.onClick.AddListener(() => { StartCoroutine(OpenCreditsPanel()); });
        CloseSettingsBtn.onClick.AddListener(CloseSettingsPanel);
        ExitBtn.onClick.AddListener(Exit);
        LeftHandBtn.onClick.AddListener(SetHandToLeft);
        RightHandBtn.onClick.AddListener(SetHandToRight);
        BreathOnBtn.onClick.AddListener(SetBreathOn);
        BreathOffBtn.onClick.AddListener(SetBreathOff);
    }

    public void Play() {
        SceneManager.LoadScene("Environment");
    }

    public void Open()
    {
        DarkBGCanvas.SetActive(true);
        Trailer.SetActive(true);
        StartCoroutine(Opening());
    }

    public void SimpleOpen() {
        Canvas.SetActive(true);
        Trailer.SetActive(true);
    }

    IEnumerator Opening()
    {
        yield return new WaitForSeconds(0.4f);
        Canvas.SetActive(true);
        Trailer.SetActive(true);
        DarkBGCanvas.SetActive(false);
    }

    void OpenSettingsPanel() {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CheckSettingsHand();
        CheckBreathing();
    }

    void CloseSettingsPanel()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    void CheckSettingsHand() {
        if (PlayerPrefs.GetString("Hand") == "right")
        {
            LeftHandBtn.interactable = true;
            RightHandBtn.interactable = false;
        }
        else if (PlayerPrefs.GetString("Hand") == "left")
        {
            LeftHandBtn.interactable = false;
            RightHandBtn.interactable = true;
        }
    }

    void CheckBreathing()
    {
        if (PlayerPrefs.GetString("Breathing") == "on")
        {
            BreathOnBtn.interactable = false;
            BreathOffBtn.interactable = true;
        }
        else if (PlayerPrefs.GetString("Breathing") == "off")
        {
            BreathOnBtn.interactable = true;
            BreathOffBtn.interactable = false;
        }
        else
        {
            BreathOnBtn.interactable = false;
            BreathOffBtn.interactable = true;
        }
    }

    void SetHandToLeft()
    {
        PlayerPrefs.SetString("Hand", "left");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Left;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Left);
        LeftHandBtn.interactable = false;
        RightHandBtn.interactable = true;
    }

    void SetHandToRight()
    {
        PlayerPrefs.SetString("Hand", "right");
        EventSystem.UsedHand = CurvedUIInputModule.Hand.Right;
        HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Right);
        LeftHandBtn.interactable = true;
        RightHandBtn.interactable = false;
    }

    void SetBreathOn()
    {
        PlayerPrefs.SetString("Breathing", "on");
        BreathOnBtn.interactable = false;
        BreathOffBtn.interactable = true;
    }

    void SetBreathOff()
    {
        PlayerPrefs.SetString("Breathing", "off");
        BreathOnBtn.interactable = true;
        BreathOffBtn.interactable = false;
    }

    IEnumerator OpenCreditsPanel()
    {
        CreditsController.Open();
        yield return new WaitForSeconds(0.4f);
        MenuContainer.SetActive(false);
        Trailer.SetActive(false);
    }

    void Exit() {
        Application.Quit();
    }
}
