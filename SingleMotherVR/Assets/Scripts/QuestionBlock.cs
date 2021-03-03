using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBlock : MonoBehaviour
{
    public YardWorkController YardWorkController;
    public Transform Avatar;
    public CharacterController AvatarController;
    public Transform CanvasContainer;
    public GameObject Canvas;
    public GameObject BtnPart;
    public Text TextBox;

    public Button YesBtn;
    public Text YesBtnText;
    public Button NoBtn;
    public Text NoBtnText;

    private Transform Target;

    private bool oneTimeAsked = false;

    private void Awake()
    {
        YesBtn.onClick.AddListener(ClickedYes);
        NoBtn.onClick.AddListener(ClickedNo);
    }

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        if (!oneTimeAsked)
        {
            ShowQuestion();
        }
    }

    void ShowQuestion()
    {
        oneTimeAsked = true;
        CanvasContainer.localRotation = Quaternion.Euler(0, Camera.main.transform.localEulerAngles.y, 0);
        Canvas.SetActive(true);
        BtnPart.SetActive(true);
        YesBtnText.text = "Yes. Mow the lawn";
        NoBtnText.text = "No. Spend money for it";
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText() {
        yield return new WaitForSeconds(0.5f);
        TextBox.text = "you need to clear the lawn";
    }

    void ClickedYes() {
        AvatarController.enabled = false;
        Avatar.localPosition = new Vector3(2.1f, -0.267f, 1.91f);
        YardWorkController.StartNewMission();
        AvatarController.enabled = true;
        Canvas.SetActive(false);
        BtnPart.SetActive(false);
    }

    void ClickedNo()
    {
        TextBox.text = "You lose 45$";
        float money = float.Parse(PlayerPrefs.GetString("BankAccaunt"));
        float newMoney = money - 45f;
        PlayerPrefs.SetString("BankAccaunt", newMoney.ToString());
        StartCoroutine(CloseBlock());
    }

    IEnumerator CloseBlock()
    {
        yield return new WaitForSeconds(1);
        Canvas.SetActive(false);
        BtnPart.SetActive(false);
    }
}
