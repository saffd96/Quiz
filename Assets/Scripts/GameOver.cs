using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Variables

    public Text stats;

    public Player player;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        Player player = FindObjectOfType<Player>();

        stats.text = $"Game Over!\nПравильных ответов: {player.rightAnswers}\nНеправильных ответов: {player.wrongAnswers}";
        Destroy(player);
    }

    #endregion
}
