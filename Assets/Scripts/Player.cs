using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private Text playerLives;

    private int lives;

    private SceneLoader sceneLoader;

    public int rightAnswers;
    public int wrongAnswers;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        SetDefault();
    }

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        playerLives.text = $"Lives: {lives}";
    }

    #endregion


    #region Public Methods

    public void GetDamage()
    {
        lives -= 1;
        if (lives == 0)
        {
            sceneLoader.ChangeScene(2);
        }
    } 

    public void RightAnswer()
    {
        rightAnswers += 1;
    }

    public void WrongAnswer()
    {
        wrongAnswers += 1;
    }

    public void SetDefault()
    {
        lives = 3;
        rightAnswers = 0;
        wrongAnswers = 0;

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    #endregion
}
