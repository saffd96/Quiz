using UnityEngine;
using UnityEngine.UI;



public class UIHelper : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Button[] answerButtons;

    [SerializeField]
    private Image questionImage;

    [SerializeField]
    private GameObject correctAnswerPopup;
    [SerializeField]
    private GameObject wrongAnswerPopup;

    #endregion


    #region Public Methods

    public void SetupUIForQuestion(QuestionData question)
    {
        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);

        questionImage.sprite = question.BGImage;
        questionText.text = question.Question;

        for (int i = 0; i < question.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }

        for (int i = question.Answers.Length; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
    }

    public void HandleSubmittedAnswer(bool isCorrect)
    {
        ToggleAnswerButtons(false);
        if (isCorrect)
        {
            ShowCorrectAnswerPoppup();
        }
        else
        {
            ShowWrongAnswerPoppup();
        }
    }

    private void ToggleAnswerButtons(bool value)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

    private void ShowCorrectAnswerPoppup()
    {
        correctAnswerPopup.SetActive(true);
    }

    private void ShowWrongAnswerPoppup()
    {
        wrongAnswerPopup.SetActive(true);
    }

    #endregion

}
