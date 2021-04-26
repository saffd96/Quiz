using UnityEngine;

[CreateAssetMenu(fileName = "New Questioln", menuName = "Question")]
public class QuestionData : ScriptableObject
{

    #region Variables

    [SerializeField]
    private string question;
    [SerializeField]
    private string[] answers;

    [SerializeField]
    private Sprite bGImage;

    [SerializeField]
    private int correctAnswer;

    #endregion


    #region Public Methods

    public string Question { get; }

    public string[] Answers { get; }

    public Sprite BGImage { get; }

    public int CorrectAnswer { get; }

    public bool Asked { get; set; }

    #endregion
}
