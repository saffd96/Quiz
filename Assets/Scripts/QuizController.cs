using System.Collections;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    #region Variables 

    private QuestionCollection questionCollection;
    private QuestionData currentQuestion;
    private UIHelper uiHelper;
    private Player player;

    [SerializeField]
    private float delayBetweenQuestions = 3f;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        questionCollection = FindObjectOfType<QuestionCollection>();
        uiHelper = FindObjectOfType<UIHelper>();
        player = FindObjectOfType<Player>();
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
        uiHelper.HandleSubmittedAnswer(isCorrect);
        if (isCorrect == false)
        {
            player.GetDamage();
            player.WrongAnswer();
        }
        else
        {
            player.RightAnswer();
        }

        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    #endregion


    #region Private Methods

    private void CurrentQuestion()
    {
        currentQuestion = questionCollection.GetUnaskedQuestion();
        uiHelper.SetupUIForQuestion(currentQuestion);
    }

    private IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenQuestions);
        CurrentQuestion();
    }

    #endregion
}
