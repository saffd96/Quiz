using System.Linq;
using UnityEngine;

public class QuestionCollection : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private QuestionData[] allQuestions;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        LoadAllQuestions();
    }

    #endregion


    #region Public Methods

    public QuestionData GetUnaskedQuestion()
    {
        ResetQuestionsIfAllHaveBeenAsked();

        var question = allQuestions
            .Where(t => t.Asked == false)
            .OrderBy(t => Random.Range(0, int.MaxValue))
            .FirstOrDefault();

        question.Asked = true;
        return question;
    }


    #endregion


    #region Private Methods

    private void LoadAllQuestions()
    {
        allQuestions = Resources.LoadAll<QuestionData>("Questions");
    }

    private void ResetQuestionsIfAllHaveBeenAsked()
    {
        if (allQuestions.Any(t => t.Asked == false) == false)
        {
            ResetQuestions();
        }
    }

    private void ResetQuestions()
    {
        foreach (var question in allQuestions)
            question.Asked = false;
    }

    #endregion

}
