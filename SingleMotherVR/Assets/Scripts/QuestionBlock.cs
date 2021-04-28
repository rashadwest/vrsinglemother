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
    public AudioSource FirstQuestionAudio;

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
        YesBtnText.text = "Yes. Spend money";
        NoBtnText.text = "No. Fix yourself";
        StartCoroutine(WriteText());
        FirstQuestionAudio.enabled = true;
    }

    IEnumerator WriteText() {
        yield return new WaitForSeconds(0.5f);
        TextBox.text = "You need to clear the lawn";
        yield return new WaitForSeconds(3.5f);
        TextBox.text = "Spend money for fix it?";
    }

    void ClickedYes() {
        TextBox.text = "You lose 45$";
        float money = float.Parse(PlayerPrefs.GetString("BankAccaunt"));
        float newMoney = money - 45f;
        PlayerPrefs.SetString("BankAccaunt", newMoney.ToString());
        StartCoroutine(CloseBlock());
        YardWorkController.Clear();
    }

    void ClickedNo()
    {
        StartCoroutine(CloseBlock());
    }

    IEnumerator CloseBlock()
    {
        yield return new WaitForSeconds(1);
        Canvas.SetActive(false);
        BtnPart.SetActive(false);
    }
}
