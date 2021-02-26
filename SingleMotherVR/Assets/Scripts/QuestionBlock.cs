using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBlock : MonoBehaviour
{
    public Transform CanvasContainer;
    public GameObject Canvas;
    public GameObject BtnPart;
    public Text TextBox;

    public Button YesBtn;
    public Text YesBtnText;
    public Button NoBtn;
    public Text NoBtnText;

    private Transform Target;

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

        ShowQuestion();
    }

    void ShowQuestion()
    {
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

    }

    void ClickedNo()
    {

    }
}
