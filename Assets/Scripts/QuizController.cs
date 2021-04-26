using System.Collections;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    #region Variables 

    private QuestionCollection questionCollection;
    private QuestionData currentQuestion;
    private UIHelper uIHelper;

    [SerializeField]
    private float delayBetweenQuestions = 3f;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        questionCollection = FindObjectOfType<QuestionCollection>();
        uIHelper = FindObjectOfType<UIHelper>();
    }

    private void Start()
    {
        CurrentQuestion();
    }

    #endregion


    #region Public Methods

    public void SubmitAnswer(int answerNumber)
    {
        bool isCorrect = answerNumber == currentQuestion.CorrectAnswer;
        uIHelper.HandleSubmittedAnswer(isCorrect);

        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    #endregion


    #region Private Methods

    private void CurrentQuestion()
    {
        currentQuestion = questionCollection.GetUnaskedQuestion();
        uIHelper.SetupUIForQuestion(currentQuestion);
    }

    private IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenQuestions);
        CurrentQuestion();
    }

    #endregion
}
