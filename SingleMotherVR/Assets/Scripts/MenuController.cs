using CurvedUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button PlayBtn;
    public Button SettingsBtn;
    public Button CreditsBtn;
    public Button ExitBtn;

    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;

    [Header("Settings")]
    public Button CloseSettingsBtn;
    public Button LeftHandBtn;
    public Button RightHandBtn;

    public CurvedUIInputModule EventSystem;

    public CurvedUIHandSwitcher HandSwitcher;

    private void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    private void Awake()
    {
        SettingsBtn.onClick.AddListener(OpenSettingsPanel);
        CloseSettingsBtn.onClick.AddListener(CloseSettingsPanel);
        ExitBtn.onClick.AddListener(Exit);
        LeftHandBtn.onClick.AddListener(SetHandToLeft);
        RightHandBtn.onClick.AddListener(SetHandToRight);
    }

    void OpenSettingsPanel() {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CheckSettingsHand();
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

    void Exit() {
        Application.Quit();
    }
}
